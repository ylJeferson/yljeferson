import json

class config():
    def pegar_valor_json(self, data):
        json_file = open('./Infra/Config/config.json')

        res=json.load(json_file)
        return res[data]
        
    def gravar_valor_json(self, primeiro_nome, ultimo_nome, telefone, email, password, pais, estado, cidade, fax, caixa_postal, endereco1, endereco2, nivel):
        dados = {
            "first_name": primeiro_nome,
            "last_name": ultimo_nome,
            "phone": telefone,
            "email": email,
            "password": password,
            "business": nivel,
            "country": pais,
            "state": estado,
            "city": cidade,
            "fax": fax,
            "postal_code": caixa_postal,
            "address1": endereco1,
            "address2": endereco2
        }

        with open('./Infra/Config/config.json', 'r') as outfile:
            json_file = json.loads(outfile.read())

        with open('./Infra/Config/config.json', 'w') as outfile:
            json_file['profile_data'] = dados
            json.dump(json_file, outfile, indent=4)