import os
import sublime_plugin

class run_file(sublime_plugin.TextCommand):
    def run(self, edit):
        os.system(f'start "" "{self.view.file_name()}"')
