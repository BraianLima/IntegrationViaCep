#################################### EN ###########################################

# Integration system with ViaCep - returning Brazil postal codes

### Developed in C#, using .Net 6

## Requirements
- C#
- .Net 6
- API Rest

## Use
- To query the GetPostalCode endpoint, an 8-character zip code must be sent
- To query the PostSearchPostalCode endpoint, an object must be sent with the state (UF), city and street name (or part of the street name), and the API will search the zip codes and return the search.

################################### PT-BR #########################################

# Sistema de integração com o ViaCep - retornando CEPs do Brasil

### Desenvolvido em C#, using .Net 6

## Requisitos
- C#
- .Net 6
- API Rest

## Utilização
- Para consultar o endpoint GetPostalCode deve ser enviado um CEP de 8 caracteres
- Para consultar o endpoint PostSearchPostalCode deve ser enviado um objeto com o estado (UF), cidade e nome da rua (ou parte do nome da rua), e a API irá pesquisar os CEPs e retornar a pesquisa.
