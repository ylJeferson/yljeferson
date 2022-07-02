import json
import names
import random
import string
import datetime as dt

class utilidades():
    def get_date(self):
        return dt.datetime.today()

    def retornar_dados_aleatorios(self):
        provedores = ['gmail', 'outlook', 'hotmail', 'yahoo', 'bing', 'bol', 'uol', 'example']
        tipos_de_conta = ['Customer', 'Supplier', 'Agent']

        primeiro_nome = names.get_first_name()
        ultimo_nome = names.get_last_name()
        telefone = self.retornar_telefone_aleatorio()
        password = self.retornar_senha_aleatoria()
        nivel = random.choice(tipos_de_conta)

        provedor = random.choice(provedores)
        email = primeiro_nome + ultimo_nome + '@' + provedor + '.com'

        dados = {
            "first_name": primeiro_nome,
            "last_name": ultimo_nome,
            "phone": telefone,
            "email": email,
            "password": password,
            "business": nivel,
            "country": "",
            "state": "",
            "city": "",
            "fax": "",
            "postal_code": "",
            "address1": "",
            "address2": ""
        }

        with open('./Infra/Config/config.json', 'r') as outfile:
            json_file = json.loads(outfile.read())

        with open('./Infra/Config/config.json', 'w') as outfile:
            json_file['profile_data'] = dados
            # json_file['profile_data'].append(dados)
            # Para usar o 'append' é necessário ir no arquivo json e mudar o account_data para lista.
            # Segue o exemplo -> "profile_data": []
            json.dump(json_file, outfile, indent=4)

        return dados

    def retornar_senha_aleatoria(self):
        length = random.randrange(8, 16)
        
        num = string.digits
        symbols = string.punctuation
        lower = string.ascii_lowercase
        upper = string.ascii_uppercase
        
        all = lower + upper + num + symbols
        temp = random.sample(all, length)
        password = "".join(temp)

        return password

    def retornar_telefone_aleatorio(self):
        numeros = [9]
        cods_area = [61, 62, 64, 65, 66, 67, 82, 71, 73, 74, 75, 77, 85, 88, 98, 99, 83, 81, 87, 86, 89, 84, 79, 68, 96, 92, 97, 91, 93, 94, 69, 95, 63, 27, 28, 31, 32, 33, 34, 35, 37, 38, 21, 22, 24, 11, 12, 13, 14, 15, 16, 17, 18, 19, 41, 42, 43, 44, 45, 46, 51, 53, 54, 55, 47, 48, 49]

        for i in range(1, 9):
            numeros.append(random.randint(0, 9))

        temp=[str(int) for int in numeros]
        temp2=[str(int) for int in cods_area]

        telefone = random.choice(temp2) + "".join(temp)
        return telefone