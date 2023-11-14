using System.ComponentModel.DataAnnotations;

public class Labirinto 
{
    private Estados[][] mapa{ set; get;}
    private int colunas {set; get;}
    private int linhas {set; get;}
    public  (int i,int e) saida{
        get => (this.linhas-2,this.colunas-2);
    }
    public (int i ,int e) entrada{init;get;} 
    [Range(0,0.6)]
    public double dencidade{ set; get;}
    public void initBordas(bool _ = false){
        for (int i = 0; i < mapa.Length; i++){
            for (int e = 0; e < mapa[i].Length; e++){
                if ((i == 0 || i == mapa.Length-1)||((e == 0 || e == mapa[i].Length-1)) ){
                    mapa[i][e] = Estados.Parede;
                }else if(_){
                    mapa[i][e] = Estados.Vasio;
                }
            }
        } 
    }
    public Labirinto(int linhas ,int colunas){
        this.linhas= linhas;
        this.colunas= colunas;
        this.mapa = new Estados[linhas][];
        for (int i = 0; i < mapa.Length; i++){
            mapa[i]= new Estados[colunas];
        }
        this.entrada = (1,1);
        //this.saida = (linhas-2,colunas-2);
    }

    public void init(){
        
        int espaco = this.linhas*this.colunas-4;
        int paredesInternas = 0;
        mapa[entrada.i][entrada.e]= Estados.Entrada;
        mapa[saida.i][saida.e]= Estados.Saida;
        var gerarParede = () => {
                Random rnd = new Random();
                int i;
                int e;
                int aredores ; 
            do{
                aredores = 0;
                i = rnd.Next(1,mapa.Length-1);
                e = rnd.Next(1,mapa[0].Length-1);

                #region checar os aredores

                void aredoresc(Estados c,int i=1) {if( c == Estados.Parede ) aredores+=i;} 
                //cima 
                aredoresc(mapa[i+1][e]);
                //baixo
                aredoresc(mapa[i-1][e] );
                //direita
                aredoresc(mapa[i][e+1] );
                //direita+cima
                aredoresc(mapa[i+1][e+1],2 );
                //direita+baixo
                aredoresc(mapa[i-1][e+1],2) ;
                //esquerda 
                aredoresc(mapa[i][e-1] );
                //esquerda+cima 
                aredoresc(mapa[i+1][e-1],2);
                //esquerda+baixo 
                aredoresc(mapa[i-1][e-1] ,2);
                #endregion 
            }while(mapa[i][e]!= Estados.Parede && aredores >= 6 );
            mapa[i][e] = Estados.Parede ;
            paredesInternas++;
        };

        do
        {
            gerarParede(); 
        } while (paredesInternas < (espaco*this.dencidade) );
        initBordas();
        if (!temCaminho(entrada.i,entrada.e))
        {
            //Console.Write();
            this.mapa = (new Labirinto(this.linhas,this.colunas)).mapa;
            init(); 
        }
        mapa[entrada.i][entrada.e]= Estados.Entrada;
            
        bool temCaminho(int linha ,int coluna ){
            // se chegou na saida retorna true 
            bool aux = false ;
            if (mapa[linha][coluna] == Estados.Saida) {
                return true;
            //se parou no espaco vazio ou na entrada continua espandindo 
            }else if (this.mapa[linha][coluna] == Estados.Vasio || this.mapa[linha][coluna] == Estados.Entrada ) {
                this.mapa[linha][coluna] = Estados.Percorido;
                //expandindo para direita 
                aux = aux || temCaminho(linha,coluna+1);
                //expandindo para baixo 
                aux = aux || temCaminho(linha-1,coluna);
                //expandindo para esquerda 
                aux = aux || temCaminho(linha,coluna-1);
                //expandindo para cima
                aux = aux || temCaminho(linha+1,coluna);
                // muda onde elepasou para caaminho se aux = true e percorido se falso 
                this.mapa[linha][coluna] = aux?Estados.Caminho:Estados.Percorido;
            }
            //se parou uma parede ou espaco percorido ou caminho retorna falso 
            return aux;       
        }
        
        
    }
    override
    public string ToString(){
        string s = string.Empty;
        for (int i = 0; i < this.mapa.Length ; i++)
        {
            for (var e = 0; e < this.mapa[i].Length; e++)
            {
                var p = this.mapa[i][e] switch
                {
                    Estados.Parede      => "██",
                    Estados.Caminho     => "° ",
                    Estados.Entrada     => "» ",
                    Estados.Saida       => "] ",
                    _                   => "  "
                };
                
                    s+= p ;
                    //s+= "";
            }
            s+= '\n';
        }
        return s;
    }

    
}
        