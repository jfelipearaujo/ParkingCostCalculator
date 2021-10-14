#language: pt-br
@fast
Funcionalidade: Valet Parking funcionalidade
  A calculadora do estacionamento pode realizar calculos para o estacionamento Valet

Cenário: Calcula o custo do estacionamento Valet
	Dado que o estacionamento é Valet
	E a duração é de <duration>
	Quando o custo for calculado
	Então o custo deve ser <cost>

	Exemplos:
		| duration          | cost    |
		| 0 minute          | 0.00€   |
		| 30 minutes        | 12.00€  |
		| 3 hours           | 12.00€  |
		| 5 hours           | 12.00€  |
		| 5 hours, 1 minute | 18.00€  |
		| 12 hours          | 18.00€  |
		| 24 hours          | 18.00€  |
		| 1 day, 1 minute   | 36.00€  |
		| 3 days            | 54.00€  |
		| 1 week            | 126.00€ |