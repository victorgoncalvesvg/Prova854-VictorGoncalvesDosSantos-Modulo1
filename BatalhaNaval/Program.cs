// See https://aka.ms/new-console-template for more information

var validaQtddJogadores = false;
int qtddJogadores = 1;

while (validaQtddJogadores == false)
{
    Console.WriteLine("Para começar, digite se é 1, ou 2 Jogadores");
    validaQtddJogadores = int.TryParse(Console.ReadLine(), out qtddJogadores);

    if (qtddJogadores != 1 && qtddJogadores != 2)
    {
        validaQtddJogadores = false;
    }

    Console.Clear();
}



if (qtddJogadores == 2)
{
    String[] nomeJogadores = new String[2];

    for (int i = 0; i <= 1; i++)
    {
        Console.WriteLine($"Digite o nome do jogador {i + 1}");
        nomeJogadores[i] = Console.ReadLine().ToUpper();

        if (i == 1) //Depois de solicitar o segundo jogador
        {
            Console.Clear();
        }
    }

    string[,] tabuleiro1 = new string[10, 10];
    string[,] tabuleiro2 = new string[10, 10];
    string[,] tabuleiro1Pontuado = new string[10, 10];
    string[,] tabuleiro2Pontuado = new string[10, 10];

    //inicializa tabuleiros
    for (int linha = 0; linha < 10; linha++)
    {
        for (int coluna = 0; coluna < 10; coluna++)
        {
            tabuleiro1[linha, coluna] = " • ";
            tabuleiro2[linha, coluna] = " • ";
            tabuleiro1Pontuado[linha, coluna] = " • ";
            tabuleiro2Pontuado[linha, coluna] = " • ";

        }
    }

    Dictionary<string, string> embarcacoes = new Dictionary<string, string>();
    embarcacoes.Add("PS", "Porta-Aviões");
    embarcacoes.Add("NT", "Navio-Tanque");
    embarcacoes.Add("DS", "Destroyers");
    embarcacoes.Add("SB", "Submarinos");


    bool tipoEmbarcacao = false;
    var embarcacao = "";
    int embarcacaoInexistente = 0;
    String escolha = "0";
    int qtddPS = 0;
    int qtddNT = 0;
    int qtddDS = 0;
    int qtddSB = 0;


    for (int jogadores = 1; jogadores <= 2; jogadores++)
    {
        qtddPS = 0;
        qtddNT = 0;
        qtddDS = 0;
        qtddSB = 0;

        for (int i = 10; i > 0;)
        {
            Console.Clear();
            if (embarcacaoInexistente > 0)
            {
                Console.WriteLine($"Embarcação não existe, uma válida.");
            }

            Console.WriteLine($"Atenção: jogador {jogadores}, <<{nomeJogadores[jogadores - 1]}>>");
            ExibeOpcoesEmbarcacoes(qtddPS, qtddNT, qtddDS, qtddSB);

            embarcacao = Console.ReadLine().ToUpper();
            tipoEmbarcacao = embarcacoes.ContainsKey(embarcacao);

            if (tipoEmbarcacao == false)
            {
                embarcacaoInexistente++;
            }

            if (tipoEmbarcacao == true)
            {
                embarcacaoInexistente = 0;




                if (embarcacao == "PS")
                {

                    if (qtddPS != 0)
                    {
                        Console.WriteLine($"Você ja colocou a embarcação {embarcacao} escolha outra");
                        tipoEmbarcacao = false;
                        continue;
                    }

                    if (jogadores == 1)
                    {
                        ImprimeTabuleiro(tabuleiro1);
                    }
                    else
                    {
                        ImprimeTabuleiro(tabuleiro2);
                    }

                    Console.WriteLine($"Escolha 5 posições para a embarcação {embarcacao} \n Restam {i} embarcações");
                    escolha = Console.ReadLine().ToUpper();
                    while ((escolha.Substring(0)).Length != 4)
                    {
                        Console.Clear();
                        ExibeOpcoesEmbarcacoes(qtddPS, qtddNT, qtddDS, qtddSB);
                        if (jogadores == 1) ImprimeTabuleiro(tabuleiro1);
                        else if (jogadores == 2) ImprimeTabuleiro(tabuleiro2);
                        Console.WriteLine($"PS espera um valor com 5 endereços. Exemplo E1E5, tente novamente: \n Restam {i} embarcações");
                        escolha = Console.ReadLine().ToUpper();
                    }
                    if (jogadores == 1)
                    {
                        ColocaEmbarcacao(tabuleiro1, escolha, embarcacao);

                        if (i == 0)
                        {
                            tipoEmbarcacao = true;
                        }

                        if (embarcacao == "PS") qtddPS++;
                        else if (embarcacao == "NT") qtddNT++;
                        else if (embarcacao == "DS") qtddDS++;
                        else if (embarcacao == "SB") qtddSB++;
                        Console.Clear();
                    }
                    else
                    {
                        ColocaEmbarcacao(tabuleiro2, escolha, embarcacao);

                        if (i == 0)
                        {
                            tipoEmbarcacao = true;
                        }

                        if (embarcacao == "PS") qtddPS++;
                        else if (embarcacao == "NT") qtddNT++;
                        else if (embarcacao == "DS") qtddDS++;
                        else if (embarcacao == "SB") qtddSB++;
                        Console.Clear();
                    }

                    i--;
                }
                else if (embarcacao == "NT")
                {
                    if (qtddNT != 0)
                    {
                        Console.WriteLine($"Você ja colocou a embarcação {embarcacao} escolha outra");
                        tipoEmbarcacao = false;
                        continue;
                    }
                    for (int nt = 0; nt < 2; nt++)
                    {
                        if (jogadores == 1)
                        {
                            ImprimeTabuleiro(tabuleiro1);
                        }
                        else
                        {
                            ImprimeTabuleiro(tabuleiro2);
                        }

                        Console.WriteLine($"Escolha 4 posições para a embarcação {embarcacao} \n Restam {i} embarcações");
                        escolha = Console.ReadLine().ToUpper();
                        while ((escolha.Substring(0)).Length != 4)
                        {
                            Console.Clear();
                            ExibeOpcoesEmbarcacoes(qtddPS, qtddNT, qtddDS, qtddSB);
                            if (jogadores == 1) ImprimeTabuleiro(tabuleiro1);
                            else if (jogadores == 2) ImprimeTabuleiro(tabuleiro2);
                            Console.WriteLine($"NT espera um valor com 4 endereços. Exemplo A1A2B1B2, tente novamente: \n Restam {i} embarcações");
                            escolha = Console.ReadLine().ToUpper();
                        }
                        if (jogadores == 1)
                        {
                            ColocaEmbarcacao(tabuleiro1, escolha, embarcacao);

                            if (i == 0)
                            {
                                tipoEmbarcacao = true;
                            }

                            if (embarcacao == "PS") qtddPS++;
                            else if (embarcacao == "NT") qtddNT++;
                            else if (embarcacao == "DS") qtddDS++;
                            else if (embarcacao == "SB") qtddSB++;
                            Console.Clear();
                        }
                        else
                        {
                            ColocaEmbarcacao(tabuleiro2, escolha, embarcacao);

                            if (i == 0)
                            {
                                tipoEmbarcacao = true;
                            }

                            if (embarcacao == "PS") qtddPS++;
                            else if (embarcacao == "NT") qtddNT++;
                            else if (embarcacao == "DS") qtddDS++;
                            else if (embarcacao == "SB") qtddSB++;
                            Console.Clear();
                        }

                        i--;
                    }

                }
                else if (embarcacao == "DS")
                {
                    if (qtddDS != 0)
                    {
                        Console.WriteLine($"Você ja colocou a embarcação {embarcacao} escolha outra");
                        tipoEmbarcacao = false;
                        continue;
                    }

                    for (int ds = 0; ds < 3; ds++)
                    {
                        if (jogadores == 1)
                        {
                            ImprimeTabuleiro(tabuleiro1);
                        }
                        else
                        {
                            ImprimeTabuleiro(tabuleiro2);
                        }

                        Console.WriteLine($"Escolha 3 posições para a embarcação {embarcacao} \n Restam {i} embarcações");
                        escolha = Console.ReadLine().ToUpper();
                        while ((escolha.Substring(0)).Length != 4)
                        {
                            Console.Clear();
                            ExibeOpcoesEmbarcacoes(qtddPS, qtddNT, qtddDS, qtddSB);
                            if (jogadores == 1) ImprimeTabuleiro(tabuleiro1);
                            else if (jogadores == 2) ImprimeTabuleiro(tabuleiro2);
                            Console.WriteLine($"DS espera um valor com 3 endereços. Exemplo C1D1C2, tente novamente: \n Restam {i} embarcações");
                            escolha = Console.ReadLine().ToUpper();
                        }
                        if (jogadores == 1)
                        {
                            ColocaEmbarcacao(tabuleiro1, escolha, embarcacao);

                            if (i == 0)
                            {
                                tipoEmbarcacao = true;
                            }

                            if (embarcacao == "PS") qtddPS++;
                            else if (embarcacao == "NT") qtddNT++;
                            else if (embarcacao == "DS") qtddDS++;
                            else if (embarcacao == "SB") qtddSB++;
                            Console.Clear();
                        }
                        else
                        {
                            ColocaEmbarcacao(tabuleiro2, escolha, embarcacao);

                            if (i == 0)
                            {
                                tipoEmbarcacao = true;
                            }

                            if (embarcacao == "PS") qtddPS++;
                            else if (embarcacao == "NT") qtddNT++;
                            else if (embarcacao == "DS") qtddDS++;
                            else if (embarcacao == "SB") qtddSB++;
                            Console.Clear();
                        }

                        i--;
                    }

                }
                else if (embarcacao == "SB")
                {

                    if (qtddSB != 0)
                    {
                        Console.WriteLine($"Você ja colocou a embarcação {embarcacao} escolha outra");
                        tipoEmbarcacao = false;
                        continue;
                    }
                    for (int sb = 0; sb < 4; sb++)
                    {
                        if (jogadores == 1)
                        {
                            ImprimeTabuleiro(tabuleiro1);
                        }
                        else
                        {
                            ImprimeTabuleiro(tabuleiro2);
                        }
                        Console.WriteLine($"Escolha 2 posições para a embarcação {embarcacao} \n Restam {i} embarcações");
                        escolha = Console.ReadLine().ToUpper();
                        while ((escolha.Substring(0)).Length != 4)
                        {
                            Console.Clear();
                            ExibeOpcoesEmbarcacoes(qtddPS, qtddNT, qtddDS, qtddSB);
                            if (jogadores == 1) ImprimeTabuleiro(tabuleiro1);
                            else if (jogadores == 2) ImprimeTabuleiro(tabuleiro2);
                            Console.WriteLine($"SB espera um valor com 2 endereços. Exemplo F1F2, tente novamente: \n Restam {i} embarcações");
                            escolha = Console.ReadLine().ToUpper();
                        }
                        if (jogadores == 1)
                        {
                            ColocaEmbarcacao(tabuleiro1, escolha, embarcacao);

                            if (i == 0)
                            {
                                tipoEmbarcacao = true;
                            }

                            if (embarcacao == "PS") qtddPS++;
                            else if (embarcacao == "NT") qtddNT++;
                            else if (embarcacao == "DS") qtddDS++;
                            else if (embarcacao == "SB") qtddSB++;
                            Console.Clear();
                        }
                        else
                        {
                            ColocaEmbarcacao(tabuleiro2, escolha, embarcacao);

                            if (i == 0)
                            {
                                tipoEmbarcacao = true;
                            }

                            if (embarcacao == "PS") qtddPS++;
                            else if (embarcacao == "NT") qtddNT++;
                            else if (embarcacao == "DS") qtddDS++;
                            else if (embarcacao == "SB") qtddSB++;
                            Console.Clear();
                        }

                        i--;
                    }

                }

            }

        }

    }

    int houveGanhador = 0;
    int contPontosJogador1 = 0;
    int contPontosJogador2 = 0;
    int aumentouPontoJogador1 = 0;
    int aumentouPontoJogador2 = 0;



    while (houveGanhador != 1)
    {

        for (int jogadores = 1; jogadores <= 2; jogadores++)
        {
            if (houveGanhador == 1) continue;

            Console.WriteLine($"Atenção Jogador {jogadores} ");
            if (jogadores == 1)
            {
                Console.Write($"<<{nomeJogadores[0]}>> sua vez \n");
                ImprimeTabuleiro(tabuleiro2Pontuado);
                Console.WriteLine($"Qual posição você deseja atacar");

                var coordenadaAtacada = Console.ReadLine();
                aumentouPontoJogador1 = contPontosJogador1;
                AtacaOponente(1, nomeJogadores, tabuleiro2, coordenadaAtacada, tabuleiro2Pontuado);
                contPontosJogador1 = VerificaSeFezPonto(1, tabuleiro2Pontuado, coordenadaAtacada, contPontosJogador1);

                ImprimeTabuleiro(tabuleiro2Pontuado);

                if (contPontosJogador1 == 30)
                {
                    Console.Clear();
                    ImprimeTabuleiro(tabuleiro2Pontuado);
                    Console.WriteLine($"Parabens jogador(a) {nomeJogadores[0]}. Você foi o(a) ganhador(a)");
                    houveGanhador = 1;
                }
                if (!(aumentouPontoJogador1 <= contPontosJogador1))
                {
                    Console.Clear();
                    Console.WriteLine($"{nomeJogadores[0]} você errou, estamos passando a vez para o jogador(a) {nomeJogadores[1]}");
                }

                //Console.WriteLine($"Houve ganhador? {houveGanhador}");
                //Console.WriteLine($"Pontos {contPontosJogador1}");
            }
            else
            if (jogadores == 2)
            {

                Console.Write($"<<{nomeJogadores[1]}>> sua vez \n");
                ImprimeTabuleiro(tabuleiro1Pontuado);
                Console.WriteLine($"Qual posição você deseja atacar");

                var coordenadaAtacada = Console.ReadLine();

                AtacaOponente(2, nomeJogadores, tabuleiro1, coordenadaAtacada, tabuleiro1Pontuado);
                contPontosJogador2 = VerificaSeFezPonto(2, tabuleiro1Pontuado, coordenadaAtacada, contPontosJogador2);
                ImprimeTabuleiro(tabuleiro1Pontuado);

                if (contPontosJogador2 == 30)
                {
                    Console.Clear();
                    ImprimeTabuleiro(tabuleiro1Pontuado);
                    Console.WriteLine($"Parabens jogador(a) {nomeJogadores[1]}. Você foi o(a) ganhador(a)");
                    houveGanhador = 1;
                }
                if (!(aumentouPontoJogador2 <= contPontosJogador2))
                {
                    Console.Clear();
                    Console.WriteLine($"{nomeJogadores[1]} você errou, estamos passando a vez para o jogador(a) {nomeJogadores[0]}");
                }

                //Console.WriteLine($"Houve ganhador? {houveGanhador}");
                // Console.WriteLine($"Pontos {contPontosJogador2}");
            }


        }


    }

}
else
{
    Console.WriteLine("A versão para jogar com a máquina está sendo desenvoldida. ");
}








static void AtacaOponente(int quemAtaca, String[] nomeJogador, string[,] tabuleiroAtacado, String coordenadaAtaque, string[,] tabuleiroPontuado)
{
    Console.Clear();
    Dictionary<char, int> linha = new Dictionary<char, int>();
    linha.Add('A', 0);
    linha.Add('B', 1);
    linha.Add('C', 2);
    linha.Add('D', 3);
    linha.Add('E', 4);
    linha.Add('F', 5);
    linha.Add('G', 6);
    linha.Add('H', 7);
    linha.Add('I', 8);
    linha.Add('J', 9);

    coordenadaAtaque = coordenadaAtaque.ToUpper();
    coordenadaAtaque = coordenadaAtaque.Substring(0);

    var linhaAtacada = linha[coordenadaAtaque[0]];
    var linhaAtacadaLetra = tabuleiroAtacado[linhaAtacada, int.Parse(coordenadaAtaque[1].ToString())];


    if ((tabuleiroAtacado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] == "PS") ||
        (tabuleiroAtacado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] == "NT") ||
        (tabuleiroAtacado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] == "DS") ||
        (tabuleiroAtacado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] == "SB"))
    {
        if (quemAtaca == 1)
        {
            Console.WriteLine($"{nomeJogador[0]} você Acertou a posição {coordenadaAtaque} do jogador adversário , agora passando a vez para o jogador(a) {nomeJogador[1]}");
        }
        else
        {
            Console.WriteLine($"{nomeJogador[1]} você Acertou a posição {coordenadaAtaque} do jogador adversário , agora passando a vez para o jogador(a) {nomeJogador[0]}");
        }

        tabuleiroAtacado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] = "-X";
        tabuleiroPontuado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] = "-X";


    }
    else
    {
        if (quemAtaca == 1)
        {
            Console.WriteLine($"{nomeJogador[0]} você errou jogando na posição {coordenadaAtaque} do jogador adversário , agora passando a vez para o jogador(a) {nomeJogador[1]}");
        }
        else
        {
            Console.WriteLine($"{nomeJogador[1]} você errou jogando na posição {coordenadaAtaque} do jogador adversário , agora passando a vez para o jogador(a) {nomeJogador[0]}");
        }
        tabuleiroAtacado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] = "-A";
        tabuleiroPontuado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] = "-A";

    }
}

static int VerificaSeFezPonto(int quemAtacou, string[,] tabuleiroAtacado, String coordenadaAtaque, int pontua)
{
    Dictionary<char, int> linha = new Dictionary<char, int>();
    linha.Add('A', 0);
    linha.Add('B', 1);
    linha.Add('C', 2);
    linha.Add('D', 3);
    linha.Add('E', 4);
    linha.Add('F', 5);
    linha.Add('G', 6);
    linha.Add('H', 7);
    linha.Add('I', 8);
    linha.Add('J', 9);

    coordenadaAtaque = coordenadaAtaque.ToUpper();
    coordenadaAtaque = coordenadaAtaque.Substring(0);

    var linhaAtacada = linha[coordenadaAtaque[0]];


    if ((tabuleiroAtacado[int.Parse(coordenadaAtaque[1].ToString()) - 1, linhaAtacada] == "-X"))
    {
        pontua++;
    }

    return pontua;

}


static void ColocaEmbarcacao(string[,] tabuleiro, String localizacao, String embarcacao)
{


    Dictionary<char, int> linha = new Dictionary<char, int>();
    linha.Add('A', 0);
    linha.Add('B', 1);
    linha.Add('C', 2);
    linha.Add('D', 3);
    linha.Add('E', 4);
    linha.Add('F', 5);
    linha.Add('G', 6);
    linha.Add('H', 7);
    linha.Add('I', 8);
    linha.Add('J', 9);


    localizacao = localizacao.ToUpper();
    localizacao = localizacao.Substring(0);
    int l = 0;
    int c = 1;
    int insereNaLinha = 0;

    var letraInicial = localizacao[0];
    var letraFinal = localizacao[2];
    int coluna = int.Parse(localizacao[1].ToString());
    int linhaInicial = linha[localizacao[0]];
    int linhaFinal = linha[localizacao[2]];

    if (embarcacao == "PS")
    {
        if (linha.ContainsKey(letraInicial) && linha.ContainsKey(letraFinal))
        {
            if (letraInicial == letraFinal)
            {
                Console.WriteLine("Entrei no letras iguais PS");
                for (int ps = 0; ps < 5; ps++)
                {
                    if (ps == 0) tabuleiro[int.Parse(localizacao[1].ToString()) - 1, linhaInicial] = embarcacao;

                    if (ps == 1) tabuleiro[int.Parse(localizacao[1].ToString()) + 1 - 1, linhaInicial] = embarcacao;

                    if (ps == 2) tabuleiro[int.Parse(localizacao[1].ToString()) + 2 - 1, linhaInicial] = embarcacao;

                    if (ps == 3) tabuleiro[int.Parse(localizacao[1].ToString()) + 3 - 1, linhaInicial] = embarcacao;

                    if (ps == 4) tabuleiro[int.Parse(localizacao[1].ToString()) + 4 - 1, linhaInicial] = embarcacao;

                }
            }
            else
            {
                for (int ps = 0; ps < 5; ps++)
                {
                    if (ps == 0) tabuleiro[coluna - 1, linhaInicial] = embarcacao;

                    if (ps == 1) tabuleiro[coluna - 1, linhaInicial + 1] = embarcacao;

                    if (ps == 2) tabuleiro[coluna - 1, linhaInicial + 2] = embarcacao;

                    if (ps == 3) tabuleiro[coluna - 1, linhaInicial + 3] = embarcacao;

                    if (ps == 4) tabuleiro[coluna - 1, linhaInicial + 4] = embarcacao;

                }
            }
        }
    }
    else
        if (embarcacao == "NT")
    {
        if (linha.ContainsKey(letraInicial) && linha.ContainsKey(letraFinal))
        {
            if (letraInicial == letraFinal)
            {
                Console.WriteLine("Entrei no letras iguais NT");
                for (int nt = 0; nt < 4; nt++)
                {
                    if (nt == 0) tabuleiro[int.Parse(localizacao[1].ToString()) - 1, linhaInicial] = embarcacao;

                    if (nt == 1) tabuleiro[int.Parse(localizacao[1].ToString()) + 1 - 1, linhaInicial] = embarcacao;

                    if (nt == 2) tabuleiro[int.Parse(localizacao[1].ToString()) + 2 - 1, linhaInicial] = embarcacao;

                    if (nt == 3) tabuleiro[int.Parse(localizacao[1].ToString()) + 3 - 1, linhaInicial] = embarcacao;


                }
            }
            else
            {
                for (int nt = 0; nt < 4; nt++)
                {
                    if (nt == 0) tabuleiro[coluna - 1, linhaInicial] = embarcacao;

                    if (nt == 1) tabuleiro[coluna - 1, linhaInicial + 1] = embarcacao;

                    if (nt == 2) tabuleiro[coluna - 1, linhaInicial + 2] = embarcacao;

                    if (nt == 3) tabuleiro[coluna - 1, linhaInicial + 3] = embarcacao;

                }
            }
        }

    }
    else
     if (embarcacao == "DS")
    {
        if (linha.ContainsKey(letraInicial) && linha.ContainsKey(letraFinal))
        {
            if (letraInicial == letraFinal)
            {
                Console.WriteLine("Entrei no letras iguais DS");
                for (int ds = 0; ds < 3; ds++)
                {
                    if (ds == 0) tabuleiro[int.Parse(localizacao[1].ToString()) - 1, linhaInicial] = embarcacao;

                    if (ds == 1) tabuleiro[int.Parse(localizacao[1].ToString()) + 1 - 1, linhaInicial] = embarcacao;

                    if (ds == 2) tabuleiro[int.Parse(localizacao[1].ToString()) + 2 - 1, linhaInicial] = embarcacao;

                    if (ds == 3) tabuleiro[int.Parse(localizacao[1].ToString()) + 3 - 1, linhaInicial] = embarcacao;

                    if (ds == 4) tabuleiro[int.Parse(localizacao[1].ToString()) + 4 - 1, linhaInicial] = embarcacao;

                }
            }
            else
            {
                for (int ds = 0; ds < 3; ds++)
                {
                    if (ds == 0) tabuleiro[coluna - 1, linhaInicial] = embarcacao;

                    if (ds == 1) tabuleiro[coluna - 1, linhaInicial + 1] = embarcacao;

                    if (ds == 2) tabuleiro[coluna - 1, linhaInicial + 2] = embarcacao;

                    if (ds == 3) tabuleiro[coluna - 1, linhaInicial + 3] = embarcacao;

                    if (ds == 4) tabuleiro[coluna - 1, linhaInicial + 4] = embarcacao;

                }
            }
        }

    }
    else
     if (embarcacao == "SB")
    {
        if (linha.ContainsKey(letraInicial) && linha.ContainsKey(letraFinal))
        {
            if (letraInicial == letraFinal)
            {
                Console.WriteLine("Entrei no letras iguais SB");
                for (int sb = 0; sb < 2; sb++)
                {
                    if (sb == 0) tabuleiro[int.Parse(localizacao[1].ToString()) - 1, linhaInicial] = embarcacao;

                    if (sb == 1) tabuleiro[int.Parse(localizacao[1].ToString()) + 1 - 1, linhaInicial] = embarcacao;


                }
            }
            else
            {
                for (int sb = 0; sb < 5; sb++)
                {
                    if (sb == 0) tabuleiro[coluna - 1, linhaInicial] = embarcacao;

                    if (sb == 1) tabuleiro[coluna - 1, linhaInicial + 1] = embarcacao;


                }
            }
        }

    }

}

static void ImprimeTabuleiro(string[,] tabuleiro)
{
    for (int linha = 0; linha < 10; linha++)
    {

        if (linha == 0) Console.Write("   1");
        if (linha == 0) Console.Write("   2");
        if (linha == 0) Console.Write("   3");
        if (linha == 0) Console.Write("   4");
        if (linha == 0) Console.Write("   5");
        if (linha == 0) Console.Write("   6");
        if (linha == 0) Console.Write("   7");
        if (linha == 0) Console.Write("   8");
        if (linha == 0) Console.Write("   9");
        if (linha == 0) Console.Write("   0");
        Console.WriteLine();

        for (int coluna = 0; coluna < 10; coluna++)
        {
            if (linha == 0 && coluna == 0) Console.Write("A");
            if (linha == 1 && coluna == 0) Console.Write("B");
            if (linha == 2 && coluna == 0) Console.Write("C");
            if (linha == 3 && coluna == 0) Console.Write("D");
            if (linha == 4 && coluna == 0) Console.Write("E");
            if (linha == 5 && coluna == 0) Console.Write("F");
            if (linha == 6 && coluna == 0) Console.Write("G");
            if (linha == 7 && coluna == 0) Console.Write("H");
            if (linha == 8 && coluna == 0) Console.Write("I");
            if (linha == 9 && coluna == 0) Console.Write("J");
            Console.Write($"|{tabuleiro[coluna, linha]}|");

        }
    }
    Console.WriteLine();
}


static void ExibeOpcoesEmbarcacoes(int qtddPS, int qtddNT, int qtddDS, int qtddSB)
{
    var menu = "Qual o tipo de embarcação? \n";

    if (qtddPS == 0) menu += "PS - Porta-Aviões (5 quadrantes \n";
    if (qtddNT == 0) menu += "NT - Navio-Tanque (4 quadrantes \n";
    if (qtddDS == 0) menu += "DS - Destroyers (3 quadrantes \n";
    if (qtddSB == 0) menu += "SB - Submarinos (2 quadrantes \n";

    Console.WriteLine(menu);

}

