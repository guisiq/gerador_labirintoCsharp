void teste(){    
    Console.WriteLine($"0.5");
    Labirinto lab = new Labirinto(45,45);
    lab.dencidade=0.55;
    lab.init();
    System.Console.WriteLine(lab);

    Console.WriteLine($"0.55");
    lab = new Labirinto(45,45);
    lab.dencidade=0.55;
    lab.init();
    System.Console.WriteLine(lab);

    Console.WriteLine($"0.6");
    lab = new Labirinto(45,45);
    lab.dencidade=0.6;
    lab.init();
    System.Console.WriteLine(lab);

    // erro de stackoverflow
    Console.WriteLine($"0.61");
    lab = new Labirinto(42,42);
    lab.dencidade=0.62;
    lab.init();
    System.Console.WriteLine(lab);
}
System.Console.WriteLine($"geracao de labirintos ");
System.Console.WriteLine($"1 - imprimir testes padrao ");
System.Console.WriteLine($"2 - definir parametros ");
var opcao = int.Parse(Console.ReadLine());
Console.WriteLine(opcao);
switch (opcao)
{
	case 1:
        teste();
        break;
    case 2: 
        Console.WriteLine($"qual a largura do labirinto ?");
        var largura = Console.Read();
        Console.ReadLine();
        Console.WriteLine($"qual o comprimento do labirinto ?");
        var comprimento = Console.Read();
        Console.ReadLine();
        var lab = new Labirinto(largura,comprimento);
        Console.WriteLine($"qual dessidade de parede do labirinto ?");
        Console.WriteLine($"insira densidades =< 0.6 ?");
        Console.ReadLine();
        lab.dencidade  = float.Parse(Console.ReadLine());
        //lab.dencidade=0.6;
        lab.init();
        System.Console.WriteLine(lab);
        break;
    default:
        System.Console.WriteLine("opcao invalida ");
        break;
        
}


   


