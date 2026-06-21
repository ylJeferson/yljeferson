import sublime, sublime_plugin

class RunSelectionCommand(sublime_plugin.TextCommand):
    def run(self, edit, **kwargs):
        import re, os
        import tempfile

        chunks = []
        for region in self.view.sel():
            chunks.append(self.view.substr(region))

        if self.view.file_name():
            working_dir = os.path.dirname(self.view.file_name())
        else:
            working_dir = os.getcwd()

        chunks = "\n".join(chunks)
        lines = filter(
            None, [l for l in chunks.split("\n") if l.strip() != ""]
        )
        source_code = "\n".join(lines)

        with tempfile.NamedTemporaryFile(suffix='.py', mode='w', delete=False) as f:
            f.write(source_code)
            window = sublime.active_window()
            window.run_command("exec", {
                "shell_cmd": "python {}".format(f.name)
            })

        # Run the build now         
        self.window.run_command("build", {"variant": "Selection"})

    def is_enabled(self):
        return len(self.view.sel()) > 0
