Este software realiza a validação das chaves de acesso para integração via API ao Mercado Livre.

Ao iniciá-lo, é solicitado que seja informado o identificador de acesso e posteriormente a chave secreta de integração. Uma vez informados esses dados, o software realiza uma requisição HTTP para a URI: https://api.mercadolibre.com/oauth/token?grant_type=client_credentials&client_id=XXXXXXXX&client_secret=YYYYYYYY

Essa URI é responsável por retornar um token de acesso as demais funções da API do sistema. No entanto, o token não é do nosso interesse neste momento.

Essa URI foi utilizada, pois com ela é necessário fornecer apenas as duas informações que estamos tentando validar (ClientId e SecretKey).

Caso uma das duas informações a serem válidadas for inconsistente, o Mercado Livre não retornará um token de acesso e o HTTP Code de resposta será 400. Em situações que os dados estejam corretos, o HTTP Code será 200 e um token de acesso será gerado.

Com isso em mente, basta realizarmos a requisição e analisar o HTTP Code retornado. Assim, conseguimos dizer se o clientID e o ClientSecret são válidos. Informação a qual é exibida na tela do usuário.

© 2018
