# Calculadora-de-Notas-POO
Repositório destinado para a versão do projeto Calculadora-de-Notas mas com POO aplicado.

# Classes

## Matéria
### Propriedades
- Id | int 
- Nome | string
- Nome Professor | string
- Periodo | string

### Métodos
Aplicar um CRUD completo para a classe Matéria, com as seguintes operações:
- Cadastrar
- Consultar
- Editar
- Deletar

## Nota
### Propriedades
- id | int
- Id Matéria | int
- Primeira Nota | float ou decimal (tenho que ver qual que se encaixa melhor)
- Segunda Nota | float ou decimal (tenho que ver qual que se encaixa melhor)
- Exame nal | float ou decimal (tenho que ver qual que se encaixa melhor)
- Nota Final | float ou decimal (tenho que ver qual que se encaixa melhor)

### Métodos
Aplicar um CRUD completo para a classe Nota, com as seguintes operações:
- Cadastrar
- Consultar
- Editar
- Deletar

## Calculadora de Notas
Será uma classe utilitária que irá conter os métodos necessários para calcular as notas.

### Propriedades
- Nenhuma

### Métodos
- SaberNotaB2: Nesse metódo será calculado o quando o aluno precisa tirar na segunda nota para passar na matéria.
- ExameFinal: Nesse método será calculado o quanto o aluno precisa tirar no exame final para passar na matéria.
- Nedia: Nesse método será calculado a média das notas do aluno.