using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        enum EstadoJogo { Jogar, NovoJogo, Ajuda, Menu, GameOver, Credito, Sair, Vitoria };

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fonte;
        Texture2D imgCosta;
        Texture2D[] imgFrente;
        Texture2D imgBotao;
        Baralho baralho;
        Credito about;
        //Carta[] baralho;
        int numCartas = 2;
        //Texture2D imgFrente2;
        Carta carta1;
        Carta carta2;
        Botao botaoVoltar;
        Botao botaoFechar;
        Botao botaoFugir;
        Botao botaoTruco;
        Vector2 posTruco;
        Botao botaoAjuda;
        Botao botaoJogar;
        Botao botaoNovoJogo;
        Botao botaoCredito;
        Botao botaoSair;
        EstadoJogo estado;
        bool usado;
        int vidas;
        MouseState meuMouse;
        Vector2 posMouse;
        bool leftButtonPressed;
        bool clickedMouse;
        int tempoPausaInteracao;
        Vector2 posMsg;
        Vector2 posVidas;
        Vector2 posMortes;
        Texture2D tCalvin;
        Texture2D tPuc;
        Texture2D tFundo;
        Texture2D propaganda;
        SpriteFont fonte18;
        SpriteFont fonteGrande;
        SpriteFont fonte14;
        SpriteFont fonte24;
        Vector2 posCalvin;
        Vector2 posTexto;
        Vector2 posRa;
        Vector2 posEmail;
        Vector2 posPropaganda;
        Rectangle rectCalvin;
        Rectangle rectPuc;
        Rectangle rectLogo;
        Texture2D tTruco;
        bool vezdoj;
        int[] Placar;
        int[] rodadasganhas;
        int pontosvalendo;
        int rodada;
        int rodadaempate;
        Vector2 posDados;
        Vector2 posPlacar;
        double tempo;
        Texture2D fundoamarelo;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            baralho = new Baralho(40);
            usado = false;
            vidas = 3;
            posDados = new Vector2(600, 400);
            posPlacar = new Vector2(700, 50);
            posVidas = new Vector2(450, 700);
            posMortes = new Vector2(60, 50);
            numCartas = 40;
            imgFrente = new Texture2D[numCartas];
            carta1 = null;
            carta2 = null;
            botaoVoltar = new Botao(400, 700, "VOLTAR");
            botaoFechar = new Botao(800, 10, "FECHAR");
            botaoFugir = new Botao(700, 550, "FUGIR");
            botaoTruco = new Botao(400, 550, "TRUCO");
            posTruco = new Vector2(350, 610);
            botaoAjuda = new Botao(400, 680, "AJUDA");
            botaoJogar = new Botao(400, 560, "CONTINUAR");
            botaoNovoJogo = new Botao(400, 500, "NOVO JOGO");
            botaoCredito = new Botao(400, 620, "SOBRE");
            botaoSair = new Botao(400, 740, "SAIR");
            estado = EstadoJogo.Menu;
            posCalvin = new Vector2(380, 230);
            posRa = new Vector2(430, 270);
            posEmail = new Vector2(390, 310);
            posPropaganda = new Vector2(850, 10);
            posTexto = new Vector2(0, 0);
            rectCalvin = new Rectangle(200, -100, 600, 450);
            rectPuc = new Rectangle(0, 350, 70, 125);
            rectLogo = new Rectangle(0, 0, 1000, 800);
                        leftButtonPressed = false;
            clickedMouse = false;
            tempoPausaInteracao = 0;
            posMsg = new Vector2(20, 50);

            vezdoj = true;
            Placar = new int[2];
            Placar[0] = 0;
            Placar[1] = 0;
            rodadasganhas = new int[2];
            rodadasganhas[0] = 0;
            rodadasganhas[1] = 0;
            pontosvalendo = 1;
            rodada = 1;
            rodadaempate = 0;
            







            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tCalvin = Content.Load<Texture2D>("Calvin");
            tPuc = Content.Load<Texture2D>("Puc");
            tFundo = Content.Load<Texture2D>("fundo");
            fundoamarelo = Content.Load<Texture2D>("bg amarelo");
            propaganda = Content.Load<Texture2D>("propaganda");
            tTruco = Content.Load<Texture2D>("fundotruco");
            fonte18 = Content.Load<SpriteFont>("Arial18");
            fonte14 = Content.Load<SpriteFont>("Arial14");
            fonte24 = Content.Load<SpriteFont>("Arial24");
            fonteGrande = Content.Load<SpriteFont>("ArialGrande");
            imgCosta = Content.Load<Texture2D>("CartaCosta");
            for (int i = 0; i < numCartas; i++)
            {
                imgFrente[i] = Content.Load<Texture2D>("Carta" + (i + 1));
            }
            fonte = Content.Load<SpriteFont>("Arial");
            imgBotao = Content.Load<Texture2D>("botao");
            about = new Credito("EDUARDO SAVINO GOMES",
                              "egomes@pucsp.br",
                              "005614",
                              imgFrente[0]);

            //imgFrente[0] = Content.Load<Texture2D>("Carta1"); 
            //imgFrente[1] = Content.Load<Texture2D>("Carta2"); 
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (estado == EstadoJogo.Jogar)
            {
                #region JOGAR
                tempo = gameTime.TotalGameTime.TotalSeconds;
                if (tempoPausaInteracao == 0)
                {
                    if (Placar[0] < 12 || Placar[1] < 12)
                    {
                        if (rodadasganhas[0] == 2 || (rodadasganhas[0] != 0 && rodadaempate != 0 && rodadaempate != 1))
                        {
                            baralho = new Baralho(40);
                            Placar[0] = Placar[0] + pontosvalendo;
                            rodadasganhas[0] = 0;
                            rodadasganhas[1] = 0;
                            pontosvalendo = 1;
                            rodada = 1;
                            rodadaempate = 0;
                            botaoTruco.Clicado = false;
                            carta1 = null;
                            carta2 = null;
                        }
                        if (rodadasganhas[1] == 2 || (rodadasganhas[1] != 0 && rodadaempate != 0 && rodadaempate != 1))
                        {
                            baralho = new Baralho(40);
                            Placar[1] = Placar[1] + pontosvalendo;
                            rodadasganhas[0] = 0;
                            rodadasganhas[1] = 0;
                            pontosvalendo = 1;
                            rodada = 1;
                            rodadaempate = 0;
                            botaoTruco.Clicado = false;
                            carta1 = null;
                            carta2 = null;
                        }


                        verificarCliqueMouse();

                        if (clickedMouse == true)
                        {

                            for (int i = 0; i < baralho.cartasjogador.Count; i++)
                            {
                                Carta crt = baralho.cartasjogador[i];
                                crt.VerificarClique((int)posMouse.X, (int)posMouse.Y);

                                if (crt.Clicada && crt != carta1)
                                {
                                    crt.X = 1;
                                    crt.Y = 2;
                                    carta1 = crt;
                                    if (vezdoj)
                                    {
                                        Random rnd = new Random();
                                        int aux = rnd.Next(0, baralho.auxiliar.Count);
                                        //aux = 0;
                                        baralho.cartascpu[baralho.auxiliar[aux]].X = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Y = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Descoberta = true;
                                        carta2 = baralho.cartascpu[baralho.auxiliar[aux]];
                                        baralho.auxiliar.RemoveAt(aux);

                                    }

                                    tempoPausaInteracao = 120;
                                    posMsg = new Vector2(20, 50);
                                    crt.Clicada = false;
                                }

                            }

                            #region botoes
                            botaoVoltar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                            if (botaoVoltar.Clicado)
                            {
                                estado = EstadoJogo.Menu;
                                botaoVoltar.Clicado = false;
                            }
                            botaoFugir.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                            if (botaoFugir.Clicado)
                            {
                                Placar[1] = Placar[1] + (pontosvalendo);
                                baralho = new Baralho(40);
                                botaoFugir.Clicado = false;
                            }
                            botaoTruco.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                            if (botaoTruco.Clicado)
                            {
                                pontosvalendo = 3;


                            }



                            clickedMouse = false;
                            #endregion botoes
                        }

                        if (tempoPausaInteracao == 0)
                        {
                            #region Comparar as Cartas
                            //Se já pegou duas cartas então compara
                            if (carta1 != null)
                            {
                                #region jogaCartasProLado
                                if (rodada == 1)
                                {
                                    carta1.X = 6;
                                    carta1.Y = 1;
                                    carta2.X = 7;
                                    carta2.Y = 1;
                                }
                                if (rodada == 2)
                                {
                                    carta1.X = 6;
                                    carta1.Y = 2;
                                    carta2.X = 7;
                                    carta2.Y = 2;
                                }
                                #endregion jogaCartasProLado
                                for (int j = 0; j < 7; j++)
                                {
                                    if (baralho.cartasmesa[j].Valor == baralho.cartastornadas[0].Valor + 1)
                                    {
                                        baralho.cartasmesa[j].Valor = 99;
                                    }
                                    if (baralho.cartastornadas[0].Valor == 9 && baralho.cartasmesa[j].Valor == 0)

                                    {
                                        baralho.cartasmesa[j].Valor = 99;
                                    }

                                }


                                #region comparaIgual
                                if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodada == 1)
                                {
                                    rodada = 2;
                                    rodadaempate = 1;
                                }
                                if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[0] == 1 && (rodada == 2 || rodada == 3))
                                {
                                    rodada = 3;
                                    rodadasganhas[0] = 2;
                                    vezdoj = true;
                                    rodadaempate = 2;
                                }
                                if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[1] == 1 && (rodada == 2 || rodada == 3))
                                {
                                    rodada = 3;
                                    rodadasganhas[1] = 2;
                                    vezdoj = true;
                                    rodadaempate = 3;
                                }
                                #endregion

                                #region comparaMaior
                                if (carta1.Euvenci(carta2))
                                {
                                    if (rodadaempate == 1)
                                    {
                                        rodadasganhas[0] = 0;
                                        botaoTruco.Clicado = false;
                                        Placar[0] = Placar[0] + pontosvalendo;
                                        vezdoj = true;
                                    }

                                    else if (rodadaempate == 0)
                                    {
                                        rodadasganhas[0]++;
                                        vezdoj = true;
                                    }

                                }
                                else if (carta2.Euvenci(carta1))
                                {
                                    if (rodadaempate == 1)
                                    {
                                        rodadasganhas[1] = 0;
                                        Placar[1] = Placar[1] + pontosvalendo;
                                    }


                                    else
                                    {
                                        rodadasganhas[1]++;
                                    }



                                    if (rodada < 3 && rodadaempate == 0)
                                    {
                                        Random rnd = new Random();
                                        int aux = rnd.Next(0, baralho.auxiliar.Count);
                                        //aux = 0;
                                        baralho.cartascpu[baralho.auxiliar[aux]].X = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Y = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Descoberta = true;
                                        carta2 = baralho.cartascpu[baralho.auxiliar[aux]];
                                        baralho.auxiliar.RemoveAt(aux);
                                        vezdoj = false;
                                    }


                                }
                                #endregion


                                //if (rodadaempate == 0)
                                //{
                                //    rodada += 1;
                                //}
                                //else
                                //{
                                //    rodada = 2;
                                //}

                                rodada += 1;
                                carta1 = null;
                                #endregion

                            }
                            if (rodada > 3)
                            {
                                baralho = new Baralho(40);
                                rodada = 1;
                                vezdoj = true;
                                botaoTruco.Clicado = false;
                            }



                        }



                    }
                    if (Placar[0] >= 12)
                    {
                        estado = EstadoJogo.GameOver;
                        Placar[0] = 0;
                        Placar[1] = 0;
                    }
                    if (Placar[1] >= 12)
                    {
                        estado = EstadoJogo.GameOver;
                        Placar[0] = 0;
                        Placar[1] = 0;
                    }

                }


                if (tempoPausaInteracao > 0)
                {
                    tempoPausaInteracao = tempoPausaInteracao - 1;
                }
                #endregion
            }
            else if (estado == EstadoJogo.NovoJogo)
            {
                if (usado == true)
                {
                    baralho = new Baralho(40);
                    
                    // baralho.Embaralhar();
                    vidas = 3;
                    usado = false;
                }
                #region JOGAR
                tempo = gameTime.TotalGameTime.TotalSeconds;
                if (tempoPausaInteracao == 0)
                {
                    if(Placar[0]<12 || Placar[1] < 12)
                    {
                        if(rodadasganhas[0] ==2 || (rodadasganhas[0]!=0 && rodadaempate != 0 && rodadaempate != 1))
                        {
                            baralho = new Baralho(40);
                            Placar[0] = Placar[0] + pontosvalendo;
                            rodadasganhas[0] = 0;
                            rodadasganhas[1] = 0;
                            pontosvalendo = 1;
                            rodada = 1;
                            rodadaempate = 0;
                            botaoTruco.Clicado = false;
                            carta1 = null;
                            carta2 = null;
                        }
                        if (rodadasganhas[1] == 2 || (rodadasganhas[1] != 0 && rodadaempate != 0 && rodadaempate != 1))
                        {
                            baralho = new Baralho(40);
                            Placar[1] = Placar[1] + pontosvalendo;
                            rodadasganhas[0] = 0;
                            rodadasganhas[1] = 0;
                            pontosvalendo = 1;
                            rodada = 1;
                            rodadaempate = 0;
                            botaoTruco.Clicado = false;
                            carta1 = null;
                            carta2 = null;
                        }


                        verificarCliqueMouse();

                        if (clickedMouse == true)
                        {

                            for (int i = 0; i < baralho.cartasjogador.Count; i++)
                            {
                                Carta crt = baralho.cartasjogador[i];
                                crt.VerificarClique((int)posMouse.X, (int)posMouse.Y);

                                if (crt.Clicada && crt != carta1)
                                {
                                    crt.X = 1;
                                    crt.Y = 2;
                                    carta1 = crt;
                                    if (vezdoj)
                                    {
                                        Random rnd = new Random();
                                        int aux = rnd.Next(0, baralho.auxiliar.Count);
                                        //aux = 0;
                                        baralho.cartascpu[baralho.auxiliar[aux]].X = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Y = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Descoberta = true;
                                        carta2 = baralho.cartascpu[baralho.auxiliar[aux]];
                                        baralho.auxiliar.RemoveAt(aux);

                                    }

                                    tempoPausaInteracao = 120;
                                    posMsg = new Vector2(20, 50);
                                    crt.Clicada = false;
                                }
                               
                            }

                            #region botoes
                            botaoVoltar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                            if (botaoVoltar.Clicado)
                            {
                                estado = EstadoJogo.Menu;
                                botaoVoltar.Clicado = false;
                            }
                            botaoFugir.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                            if (botaoFugir.Clicado)
                            {
                                Placar[1] = Placar[1] + (pontosvalendo);
                                baralho = new Baralho(40);
                                botaoFugir.Clicado = false;
                            }
                            botaoTruco.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                            if (botaoTruco.Clicado)
                            {
                                pontosvalendo = 3;
                                
                                
                            }



                            clickedMouse = false;
                            #endregion botoes
                        }

                        if (tempoPausaInteracao == 0)
                        {
                            #region Comparar as Cartas
                            //Se já pegou duas cartas então compara
                            if (carta1 != null)
                            {
                                #region jogaCartasProLado
                                if (rodada == 1)
                                {
                                    carta1.X = 6;
                                    carta1.Y = 1;
                                    carta2.X = 7;
                                    carta2.Y = 1;
                                }
                                if (rodada == 2)
                                {
                                    carta1.X = 6;
                                    carta1.Y = 2;
                                    carta2.X = 7;
                                    carta2.Y = 2;
                                }
                                #endregion jogaCartasProLado
                                for (int j = 0; j < 7; j++)
                                {
                                    if (baralho.cartasmesa[j].Valor == baralho.cartastornadas[0].Valor + 1)
                                    {
                                        baralho.cartasmesa[j].Valor = 99;
                                    }
                                    if (baralho.cartastornadas[0].Valor == 9 && baralho.cartasmesa[j].Valor == 0)

                                    {
                                        baralho.cartasmesa[j].Valor = 99;
                                    }

                                }


                                #region comparaIgual
                                if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodada == 1)
                                {
                                    rodada = 2;
                                    rodadaempate = 1;
                                }
                                if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[0] == 1 && (rodada == 2 || rodada == 3))
                                {
                                    rodada = 3;
                                    rodadasganhas[0] = 2;
                                    vezdoj = true;
                                    rodadaempate = 2;
                                }
                                if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[1] == 1 && (rodada == 2 || rodada == 3))
                                {
                                    rodada = 3;
                                    rodadasganhas[1] = 2;
                                    vezdoj = true;
                                    rodadaempate = 3;
                                }
                                #endregion

                                #region comparaMaior
                                if (carta1.Euvenci(carta2))
                                {
                                    if (rodadaempate == 1)
                                    {
                                        rodadasganhas[0] = 0;
                                        botaoTruco.Clicado = false;
                                        Placar[0] = Placar[0] + pontosvalendo;
                                        vezdoj = true;
                                    }                                    

                                    else if(rodadaempate == 0)
                                    {
                                        rodadasganhas[0]++;
                                        vezdoj = true;
                                    }                 
                                    
                                }
                                else if(carta2.Euvenci(carta1) )
                                {
                                    if (rodadaempate == 1)
                                    {
                                        rodadasganhas[1] = 0;
                                        Placar[1] = Placar[1]+pontosvalendo;
                                    }


                                    else
                                    {
                                        rodadasganhas[1]++;
                                    }
                                      
                                    
                                    
                                    if (rodada < 3 && rodadaempate == 0 )
                                    {
                                        Random rnd = new Random();
                                        int aux = rnd.Next(0, baralho.auxiliar.Count);
                                        //aux = 0;
                                        baralho.cartascpu[baralho.auxiliar[aux]].X = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Y = 2;
                                        baralho.cartascpu[baralho.auxiliar[aux]].Descoberta = true;
                                        carta2 = baralho.cartascpu[baralho.auxiliar[aux]];
                                        baralho.auxiliar.RemoveAt(aux);
                                        vezdoj = false;
                                    }


                                }
                                #endregion
                                

                                //if (rodadaempate == 0)
                                //{
                                //    rodada += 1;
                                //}
                                //else
                                //{
                                //    rodada = 2;
                                //}

                                rodada += 1;
                                carta1 = null;
                                #endregion

                            }
                            if (rodada > 3)
                            {
                                baralho = new Baralho(40);
                                rodada = 1;
                                vezdoj = true;
                                botaoTruco.Clicado = false;
                            }

                            

                        }
                        
                        

                    }
                    if (Placar[0]>=12)
                    {
                        estado = EstadoJogo.GameOver;
                        Placar[0] = 0;
                        Placar[1] = 0;
                    }
                    if (Placar[1] >= 12)
                    {
                        estado = EstadoJogo.GameOver;
                        Placar[0] = 0;
                        Placar[1] = 0;
                    }

                }
                    

                if (tempoPausaInteracao > 0)
                {
                    tempoPausaInteracao = tempoPausaInteracao - 1;
                }
                #endregion

            }
            else if (estado == EstadoJogo.Credito)
            {
                rectPuc.X += 2;


                if (rectPuc.X > GraphicsDevice.Viewport.Width)
                {
                    rectPuc.X = -200;
                    rectPuc.Y = 350;

                }
                posTexto.X = rectPuc.X - 50;
                posTexto.Y = rectPuc.Y - 10;
                verificarCliqueMouse();

                if (clickedMouse == true)
                {
                    botaoVoltar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    if (botaoVoltar.Clicado)
                    {
                        estado = EstadoJogo.Menu;
                        botaoVoltar.Clicado = false;
                    }
                    clickedMouse = false;
                }
            }
            else if (estado == EstadoJogo.GameOver)
            {
                verificarCliqueMouse();
                if (clickedMouse == true)
                {
                    botaoFechar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    if (botaoFechar.Clicado)
                    {
                        estado = EstadoJogo.Menu;
                        botaoFechar.Clicado = false;
                    }
                    clickedMouse = false;
                }
            }
            else if (estado == EstadoJogo.Ajuda)
            {
                verificarCliqueMouse();
                if (clickedMouse == true)
                {
                    botaoVoltar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    if (botaoVoltar.Clicado)
                    {
                        estado = EstadoJogo.Menu;
                        botaoVoltar.Clicado = false;
                    }
                    clickedMouse = false;
                }
            }
            else if (estado == EstadoJogo.Menu)
            {
                #region MENU
                verificarCliqueMouse();
                if (clickedMouse)
                {
                    botaoJogar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    botaoAjuda.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    botaoNovoJogo.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    botaoCredito.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    botaoSair.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    if (botaoJogar.Clicado)
                    {
                        estado = EstadoJogo.Jogar;

                        botaoJogar.Clicado = false;
                    }
                    else if (botaoNovoJogo.Clicado)
                    {
                        estado = EstadoJogo.NovoJogo;
                        usado = true;
                        botaoNovoJogo.Clicado = false;
                    }
                    else if (botaoAjuda.Clicado)
                    {
                        estado = EstadoJogo.Ajuda;
                        usado = true;
                        botaoAjuda.Clicado = false;
                    }
                    else if (botaoCredito.Clicado)
                    {
                        estado = EstadoJogo.Credito;
                        botaoCredito.Clicado = false;
                    }
                    else if (botaoSair.Clicado)
                    {
                        estado = EstadoJogo.Sair;
                        botaoSair.Clicado = false;
                    }
                    clickedMouse = false;
                }
                #endregion
            }
            else if (estado == EstadoJogo.Sair)
            {
                Exit();
            }
            base.Update(gameTime);

        }

        private void verificarCliqueMouse()
        {
            meuMouse = Mouse.GetState();
            posMouse.X = meuMouse.X;
            posMouse.Y = meuMouse.Y;
            if (meuMouse.LeftButton == ButtonState.Pressed)
            {
                leftButtonPressed = true;
            }

            if (meuMouse.LeftButton == ButtonState.Released &&
                leftButtonPressed == true)
            {
                clickedMouse = true;
                leftButtonPressed = false;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSeaGreen);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (estado == EstadoJogo.Jogar)
            {
                spriteBatch.Draw(fundoamarelo, rectLogo, Color.White);
                spriteBatch.DrawString(fonte, "PLACAR: \n  JOGADOR: " + Placar[0] + "   " + "CPU: " + Placar[1], posPlacar, Color.Black);
                //spriteBatch.DrawString(fonte, "rodada" + rodada + "   \n"
                //    + "rodadasganhasJOG" + rodadasganhas[0] + "   "
                //    + "\n rodadasganhascpu" + rodadasganhas[1] + "   "
                //    + "\n rodadaempate" + rodadaempate, posDados, Color.Black);

                #region DRAW JOGAR
                DrawObjetos.DrawCarta(baralho.cartastornadas[0], spriteBatch, imgCosta, imgFrente[baralho.cartastornadas[0].Image]);

                for (int i = 0; i < 3; i++)
                {
                    DrawObjetos.DrawCarta(baralho.cartasjogador[i], spriteBatch, imgCosta,
                                imgFrente[baralho.cartasjogador[i].Image]);
                    DrawObjetos.DrawCarta(baralho.cartascpu[i], spriteBatch, imgCosta,
                                imgFrente[baralho.cartascpu[i].Image]);
                }



                DrawObjetos.DrawBotao(botaoTruco, spriteBatch, imgBotao, fonte);

                if (botaoTruco.Clicado)
                {
                    spriteBatch.DrawString(fonte, "TA TRUCADO MALANDRO", posTruco, Color.Yellow);
                }
                DrawObjetos.DrawBotao(botaoFugir, spriteBatch, imgBotao, fonte);

                if (tempoPausaInteracao > 0)
                {
                    posMsg.X += 2;
                    for (int j = 0; j < 7; j++)
                    {
                        if (baralho.cartasmesa[j].Valor == baralho.cartastornadas[0].Valor + 1)
                        {
                            baralho.cartasmesa[j].Valor = 99;
                        }
                        if (baralho.cartastornadas[0].Valor == 9 && baralho.cartasmesa[j].Valor == 0)

                        {
                            baralho.cartasmesa[j].Valor = 99;
                        }

                    }
                    if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodada == 1)
                    {
                        //rodada = 2;
                        //rodadaempate = 1;
                        spriteBatch.DrawString(fonteGrande, "EMPATOU", posMsg, Color.Yellow);

                    }
                    if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[0] == 1 && (rodada == 2 || rodada == 3))
                    {
                        //rodada = 3;
                        //rodadasganhas[0]=2;
                        //vezdoj = true;
                        //rodadaempate = 2;
                        spriteBatch.DrawString(fonteGrande, "EMPATOU", posMsg, Color.Yellow);
                    }
                    if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[1] == 1 && (rodada == 2 || rodada == 3))
                    {
                        //rodada = 3;
                        //rodadasganhas[1]=2;
                        //vezdoj = true;
                        //rodadaempate = 3;
                        spriteBatch.DrawString(fonteGrande, "EMPATOU", posMsg, Color.Yellow);
                    }
                    if (carta1.Euvenci(carta2))
                    {
                        spriteBatch.DrawString(fonteGrande, "GANHOU!!!", posMsg, Color.Green);

                    }
                    else if (carta2.Euvenci(carta1))
                    {

                        spriteBatch.DrawString(fonteGrande, "PERDEU...", posMsg, Color.Red);
                    }
                }
                DrawObjetos.DrawBotao(botaoVoltar, spriteBatch,
                                      imgBotao, fonte);
                #endregion

            }
            else if (estado == EstadoJogo.NovoJogo)
            {
                spriteBatch.Draw(fundoamarelo, rectLogo, Color.White);
                spriteBatch.DrawString(fonte, "PLACAR: \n  JOGADOR: " + Placar[0]+"   " + "CPU: "+Placar[1], posPlacar, Color.Black);
               

                #region DRAW JOGAR
                DrawObjetos.DrawCarta(baralho.cartastornadas[0], spriteBatch, imgCosta, imgFrente[baralho.cartastornadas[0].Image]);

                for (int i = 0; i < 3; i++)
                {
                    DrawObjetos.DrawCarta(baralho.cartasjogador[i], spriteBatch, imgCosta,
                                imgFrente[baralho.cartasjogador[i].Image]);
                    DrawObjetos.DrawCarta(baralho.cartascpu[i], spriteBatch, imgCosta,
                                imgFrente[baralho.cartascpu[i].Image]);
                }

                
                
                DrawObjetos.DrawBotao(botaoTruco, spriteBatch, imgBotao, fonte);
                
                if(botaoTruco.Clicado )
                {
                    spriteBatch.DrawString(fonte, "TA TRUCADO MALANDRO", posTruco, Color.Yellow);
                }
                DrawObjetos.DrawBotao(botaoFugir, spriteBatch, imgBotao, fonte);

                if (tempoPausaInteracao > 0)
                {
                    posMsg.X += 2;
                    for (int j = 0; j < 7; j++)
                    {
                        if (baralho.cartasmesa[j].Valor == baralho.cartastornadas[0].Valor + 1)
                        {
                            baralho.cartasmesa[j].Valor = 99;
                        }
                        if (baralho.cartastornadas[0].Valor == 9 && baralho.cartasmesa[j].Valor == 0)

                        {
                            baralho.cartasmesa[j].Valor = 99;
                        }

                    }
                    if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodada == 1)
                    {
                        //rodada = 2;
                        //rodadaempate = 1;
                        spriteBatch.DrawString(fonteGrande, "EMPATOU", posMsg, Color.Yellow);

                    }
                    if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[0] == 1 && (rodada == 2 || rodada == 3))
                    {
                        //rodada = 3;
                        //rodadasganhas[0]=2;
                        //vezdoj = true;
                        //rodadaempate = 2;
                        spriteBatch.DrawString(fonteGrande, "EMPATOU", posMsg, Color.Yellow);
                    }
                    if (carta1.Igual(carta2) && carta1.Valor != 99 && carta2.Valor != 99 && rodadasganhas[1] == 1 && (rodada == 2 || rodada == 3))
                    {
                        //rodada = 3;
                        //rodadasganhas[1]=2;
                        //vezdoj = true;
                        //rodadaempate = 3;
                        spriteBatch.DrawString(fonteGrande, "EMPATOU", posMsg, Color.Yellow);
                    }
                    if (carta1.Euvenci(carta2))
                    {
                        spriteBatch.DrawString(fonteGrande, "GANHOU!!!", posMsg, Color.Green);
                        
                    }
                    else if (carta2.Euvenci(carta1))
                    {

                        spriteBatch.DrawString(fonteGrande, "PERDEU...", posMsg, Color.Red);
                    }
                }
                DrawObjetos.DrawBotao(botaoVoltar, spriteBatch,
                                      imgBotao, fonte);
                #endregion
                
            }
            else if (estado == EstadoJogo.Menu)
            {
                spriteBatch.Draw(tTruco, rectLogo, Color.White);
                #region DRAW MENU
                DrawObjetos.DrawBotao(botaoJogar, spriteBatch, imgBotao, fonte);
                DrawObjetos.DrawBotao(botaoAjuda, spriteBatch, imgBotao, fonte);
                DrawObjetos.DrawBotao(botaoNovoJogo, spriteBatch, imgBotao, fonte);
                DrawObjetos.DrawBotao(botaoCredito, spriteBatch, imgBotao, fonte);
                DrawObjetos.DrawBotao(botaoSair, spriteBatch, imgBotao, fonte);
                #endregion

            }
            else if (estado == EstadoJogo.Credito)
            {
                //spriteBatch.DrawString(fonte, "TELA DE CREDIO", Vector2.Zero, Color.Red);
                //DrawObjetos.Credito(about, spriteBatch, fonte);
            
                Vector2 pos = new Vector2(0, 0);
                Rectangle rectFundo = new Rectangle(0, 0,
                                      GraphicsDevice.Viewport.Width,
                                      GraphicsDevice.Viewport.Height);
                // TODO: Add your drawing code here
            
                spriteBatch.Draw(tFundo, rectFundo, Color.White);
                spriteBatch.Draw(tCalvin, rectCalvin, Color.White);
                spriteBatch.Draw(tPuc, rectPuc, Color.White);
            
            
                spriteBatch.DrawString(fonte, "Calvin do Amaral Franca", posCalvin, Color.Black);
                spriteBatch.DrawString(fonte14, "RA00207814", posRa, Color.Black);
                spriteBatch.DrawString(fonte14, "calvin.franca@gmail.com", posEmail, Color.Black);
                spriteBatch.DrawString(fonte14, "LPG3 - Jogos Digitais", posTexto, Color.Red);
                DrawObjetos.DrawBotao(botaoVoltar, spriteBatch, imgBotao, fonte);
            }
            else if (estado == EstadoJogo.GameOver)
            {
                Rectangle rectFundo = new Rectangle(0, 0,
                                      GraphicsDevice.Viewport.Width,
                                      GraphicsDevice.Viewport.Height);
                spriteBatch.Draw(propaganda, rectFundo, Color.White);
                spriteBatch.DrawString(fonte18, ((int)(6-((gameTime.TotalGameTime.TotalSeconds - tempo) %6))).ToString(), posPropaganda, Color.Red);
                if (tempo +5 <=gameTime.TotalGameTime.TotalSeconds)
                {
                    DrawObjetos.DrawBotao(botaoFechar, spriteBatch, imgBotao, fonte);
                }
            }           
            else if (estado == EstadoJogo.Ajuda)
            {
                spriteBatch.Draw(tTruco, rectLogo, Color.White);
                spriteBatch.DrawString(fonte24, " JOGUE TRUCO COM UMA CPU MUITO BURRA \n NAO PODE EMPATAR MAIS DE UMA VEZ", posMortes, Color.Black);


                DrawObjetos.DrawBotao(botaoVoltar, spriteBatch, imgBotao, fonte);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
