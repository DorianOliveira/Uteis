Uteis
=====

##Xml Documentation Handle


Essa classe tem por finalidade acessar o arquivo de comentários XML no .NET. Esses comentários são criados quando se comenta utilizando-se de três barras "///".


###Uso Padrão

O método principal utilizado é GetXmlDocumentationClass. Ele pode receber 2, 3 ou 4 parâmetros.

```csharp

//Inicializa o objeto
XmlDocumentation objXmlDocumentation = new XmlDocumentation();

//Cria um enum do tipo IDSTRING, que existe dentro de XmlDocumentation. As opções sao:
//IDSTRING.NAMESPACE
//IDSTRING.CLASS
//IDSTRING.FIELD
//IDSTRING.PROPERTY
//IDSTRING.METHOD
//IDSTRING.EVENT
objXmlDocumentation.IDSTRING ID_STRING = objXmlDocumentation.IDSTRING.CLASS;

//Recupera o struct Documentation, onde você pode recuperar:
//ID_STRING -
//members
objXmlDocumentation.Documentation objDocumentation = 
  GetXmlDocumentationClass("SeuNamespace.SuaClasse", ID_STRING);
```
  
###Outras formas de utilização

O método possui mais dois outros parâmetros. O primeiro deles define se a busca será feita no namespace inteiro, ou seja, apenas na classe em questão (comportamento padrão - TRUE) ou em todas as classes do namespace.

Exemplo de uso:

```CSHARP

//Nesse caso a busca será feita em todas as classes do namespace

XmlDocumentation objXmlDocumentation = new XmlDocumentation();
objXmlDocumentation.IDSTRING ID_STRING = objXmlDocumentation.IDSTRING.CLASS;
objXmlDocumentation.Documentation objDocumentation =  
  GetXmlDocumentationClass("SeuNamespace.SuaClasse", ID_STRING, false);
  
```
O segundo parâmetro informa se a busca será feita em filhos. Isso só importa se duas condições forem satisfeitas: Quando a busca é por classe, e essa classe possui classes-filhas. Como você já pode perceber, não é um caso muito comum.

O comportamento padrão é TRUE -  busca feita em todos os filhos.

Observação: Se a busca não for feita em classe (for feita em field, property, method, etc), será retornado todos os elementos encontrados, sendo eles de classes-filhas ou não.

```CSHARP

//Nesse caso a busca será feita apenas na classe em questão, e não nas classes-filhas, se houver

XmlDocumentation objXmlDocumentation = new XmlDocumentation();
objXmlDocumentation.IDSTRING ID_STRING = objXmlDocumentation.IDSTRING.CLASS;
objXmlDocumentation.Documentation objDocumentation =  
  GetXmlDocumentationClass("SeuNamespace.SuaClasse", ID_STRING, true, false);
  
```

###Outras formas de utilização

É uma classe simples feita para fins de experimento, e ainda não contempla todas as possibilidades (você deve ter percebido que se tentar buscar apenas membros da classe em questão, sem trazer os das classes filha, não será possível).

Se você estiver desenvolvendo algo simples para trabalhar com essas informações, pode ser útil pra você. Se você quer gerar documentação completa de seu projeto, é recomendado utilizar um programa que faça isso (existem vários gratuitos que fazem esse trabalho pra você), pois não há necessidade de reinventar a roda ne :).

Bom trabalho e bons estudos.




