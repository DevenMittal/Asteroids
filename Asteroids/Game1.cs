using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Asteroids
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GameTime time = new GameTime();
        GameTime score = new GameTime();
        GameTime spawn = new GameTime();

        //int millis = 0;

        Random rand = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List <Asteroid> asteroids;
        Texture2D pixel;
        Texture2D ship;
        Texture2D bulletimage;
        Texture2D[] images;
        Ship ship1;
        List<Bullet> bullet;
        SpriteFont font1;
        Vector2 position;
        Vector2 position2;
        Vector2 something;
        Vector2 shipposition;
        Color tint;
        Vector2 speed;
        Rectangle temppos;
        Vector2 bulletposition;
        float bulletangle;
        Rectangle hitbox;
        Rectangle hitbox2;
        Rectangle asteroidhitbox;
        Rectangle shiphitbox;
        int lives = 3;
        float anglestep;
        bool bulletmove = false;
        bool a = false;
        bool shoot = true;
        bool add = false;
        bool restart = false;
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
           // new Vector2(rand.Next(0, GraphicsDevice.Viewport.Width + 1), rand.Next(0, GraphicsDevice.Viewport.Height + 1));
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            asteroids = new List<Asteroid>();
            images = new Texture2D[4];

            bullet = new List<Bullet>();
            images[0] = Content.Load<Texture2D>("asteroid1");
            images[1] = Content.Load<Texture2D>("asteroid2");
            images[2] = Content.Load<Texture2D>("asteroid3");
            images[3] = Content.Load<Texture2D>("asteroid4");
            bulletimage = Content.Load<Texture2D>("bullet");
            ship = Content.Load<Texture2D>("shipthing");
             pixel = Content.Load<Texture2D>("pixel");
            position = new Vector2(0, 0);
            position2 = new Vector2(100,200);
            font1 = Content.Load<SpriteFont>("font1");
            tint = Color.White;
            shipposition = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            speed = new Vector2(3, 3);
            shiphitbox = new Rectangle((int)shipposition.X, (int)shipposition.Y, ship.Width, ship.Height);
            bulletposition = new Vector2(100, 100);
            ship1 = new Ship(ship, tint, shiphitbox, shipposition);
            ship1.speed = new Vector2(2, 2);

            asteroids.Add(new Asteroid(images[rand.Next(1, 4)], position, speed, tint, new Rectangle((int)position.X, (int)position.Y, 125, 125)));
            asteroids.Add(new Asteroid(images[rand.Next(1, 4)], position = new Vector2(300,300), speed, tint, new Rectangle((int)position.X, (int)position.Y, 125, 125)));

            //bullet[0].Anglestep = ship1.AngledSpeed;

            // asteroids.Add(new asteroid(images[rand.Next(1, 4)], position2, speed, tint, hitbox2));


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
            KeyboardState ks = new KeyboardState();
            time.TotalGameTime += gameTime.ElapsedGameTime;
            score.TotalGameTime += gameTime.ElapsedGameTime;
            spawn.TotalGameTime += gameTime.ElapsedGameTime;

            //millis += (int)  gameTime.ElapsedGameTime.TotalMilliseconds;

            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Bounce(GraphicsDevice);
            }

            for (int i = 0; i < bullet.Count; i++)
            {
                bullet[i].rect = new Rectangle((int)bullet[i].position.X-bullet[i].image.Width/2, (int)bullet[i].position.Y-bullet[i].image.Height/2, bullet[i].image.Width, bullet[i].image.Height);
            }

           
            ship1.rect = new Rectangle((int)ship1.position.X-ship1.image.Width/2, (int)ship1.position.Y-ship1.image.Height/2, ship1.image.Width, ship1.image.Height);
            









            for (int i = 0; i < asteroids.Count; i++)
            {
                for (int j = i+1; j < asteroids.Count; j++)
                {
                    if (asteroids[i].hitbox.Intersects(asteroids[j].hitbox))
                    {

                        something = asteroids[i].speed;
                        asteroids[i].speed = asteroids[j].speed;
                        asteroids[j].speed = something;
                        a = true;
                        asteroids[i].position += asteroids[i].speed*2;
                        asteroids[j].position += asteroids[j].speed*2;
                        Console.WriteLine("a");
                        //for (int k = 0; k < asteroids.Count; k++)
                        //{
                        //    asteroids[i].Bounce(GraphicsDevice);
                        //}
                        if (a == true)
                        {
                            break;
                        }
                        
                    }
                }
                if (a == true)
                {
                    break;
                }
            }







            if (time.TotalGameTime.TotalMilliseconds >= 1000)
            //if (millis >= 1000)
            {
                shoot = true;
                time = new GameTime();
                //millis = 0;
            }

            if (spawn.TotalGameTime.TotalMilliseconds >= 5000)
            //if (millis >= 1000)
            {
                spawn = new GameTime();
                add = true;
                //millis = 0;
            }

            if (shoot == true)
            {

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {

                    bullet.Add(new Bullet(bulletimage, tint, hitbox, ship1.position, ship1.origin, ship1.angle));

                    for (int i = 0; i < bullet.Count; i++)
                    {
                        bullet[i].speed = new Vector2(5, 5);
                    }
                    bulletmove = true;
                    shoot = false;
                }
            }
            if (bulletmove == true)
            {
                for (int i = 0; i < bullet.Count; i++)
                {
                    bullet[i].Move();
                }
            }
            ship1.Move();
            for (int i = 0; i < bullet.Count; i++)
            {
                for (int j = 0; j < asteroids.Count; j++)
                {

                    



                    





                    if (bullet[i].rect.Intersects(asteroids[j].hitbox)&&asteroids[j].hitbox.Width>100  && asteroids[j].hitbox.Height> 100)
                    {
                        asteroids.Add(new Asteroid(images[rand.Next(1, 4)], asteroids[j].position, speed, tint, new Rectangle((int)asteroids[j].position.X,(int)asteroids[j].position.Y,asteroids[j].hitbox.Width*2/3, asteroids[j].hitbox.Height*2/3)));
                        asteroids.Add(new Asteroid(images[rand.Next(1, 4)], asteroids[j].position + new Vector2(asteroids[j].hitbox.Width/2, asteroids[j].hitbox.Height/2), speed, tint, new Rectangle((int)asteroids[j].position.X+asteroids[j].hitbox.Width*2/3, (int)asteroids[j].position.Y + asteroids[j].hitbox.Height*2/3, asteroids[j].hitbox.Width*2 / 3, asteroids[j].hitbox.Height*2 / 3)));
                        asteroids.Remove(asteroids[j]);
                        bullet.Remove(bullet[i]);
                        break;

                    }
                    else if(bullet[i].rect.Intersects(asteroids[j].hitbox) && asteroids[j].hitbox.Width < 100 && asteroids[j].hitbox.Height < 100)
                    {
                        asteroids.Remove(asteroids[j]);
                    }
                }
            }

            for (int i = 0; i < asteroids.Count; i++)
            {
                if (ship1.rect.Intersects(asteroids[i].hitbox))
                {
                    lives--;
                    asteroids.Remove(asteroids[i]);
                    ship1.position = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
                    break;
                }
            }

            if (restart == true)
            {
                ship1.speed = new Vector2(0, 0);
                for (int i = 0; i < asteroids.Count; i++)
                {
                    asteroids[i].speed = new Vector2(0,0);
                }
                restart = false;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                ship1.position = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
                asteroids.Clear();
                bullet.Clear();
                
                asteroids.Add(new Asteroid(images[rand.Next(1, 4)], new Vector2(0,0), speed, tint, new Rectangle((int)position.X, (int)position.Y, 125, 125)));
                asteroids.Add(new Asteroid(images[rand.Next(1, 4)], new Vector2(GraphicsDevice.Viewport.Width-200, GraphicsDevice.Viewport.Height-200), speed, tint, new Rectangle((int)position.X, (int)position.Y, 125, 125)));
                time = new GameTime();
                for (int i = 0; i < asteroids.Count; i++)
                {
                    asteroids[i].speed = new Vector2(3, 3);
                }
                ship1.speed = new Vector2(3, 3);
                lives = 3;
            }


            if (add == true)
            {
                asteroids.Add(new Asteroid(images[rand.Next(1, 4)], new Vector2(0, 0), speed, tint, new Rectangle(0, 0, 125, 125)));
                Asteroid temp = asteroids[asteroids.Count - 1];
                bool isIntersecting = false;
                for (int i = asteroids.Count - 1; i >= 0; i--)
                {
                    if (temp.hitbox.Intersects(asteroids[i].hitbox) && asteroids[i] != temp)
                    {
                        asteroids.Remove(temp);
                        isIntersecting = true;
                    }
                }
                if (!isIntersecting)
                {
                    add = false;
                }
                
            }

            //Every x amount of game time, another asteroid spawns
            //The higher the score, the quicker the spawns
















            //for (int i = 0; i < asteroids.Count; i++)
            //{
            //    for (int j = i+1; j < asteroids.Count; j++)
            //    {
            //        Vector2 center1 = new Vector2(asteroids[i].position.X + asteroids[i].image.Width / 2, asteroids[i].position.Y + asteroids[i].image.Height / 2);
            //        Vector2 center2 = new Vector2(asteroids[j].position.X + asteroids[j].image.Width / 2, asteroids[j].position.Y + asteroids[j].image.Height / 2);

            //        int radius1 =(int)asteroids[i].image.Width/2;
            //        int radius2 =(int)asteroids[j].image.Width/2;

            //        int distance = (int)Math.Sqrt((center1.X - center2.X) * (center1.X - center2.X) + (center1.Y - center2.Y) * (center1.Y - center2.Y));



            //        if (distance < radius1+radius2)
            //        {
            //            asteroids[i].speed *= -1;
            //            asteroids[j].speed *= -1;
            //            a = true;
            //            Console.WriteLine("collision");
            //            for (int k = 0; k < asteroids.Count; k++)
            //            {
            //                asteroids[k].Bounce(GraphicsDevice);
            //            }
            //            if (a)
            //            {
            //                break;
            //            }
            //        }            

            //    }
            //    if (a)
            //    {
            //        break;
            //    }
            //}



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (lives == 0)
            {
                restart = true;
            }

            for (int i = 0; i < asteroids.Count; i++)
            {
                spriteBatch.Draw(asteroids[i].image, asteroids[i].hitbox, Color.White);
               //spriteBatch.Draw(pixel, asteroids[i].hitbox, Color.Lerp(Color.Transparent, Color.Red, .2f));
            }
            

            //spriteBatch.Draw(asteroids[0].image, new Rectangle(100, 100, 10, 10), Color.White);
           // spriteBatch.Draw(pixel, ship1.rect, Color.Lerp(Color.Transparent, Color.Red, .2f));

            spriteBatch.DrawString(font1, "Lives:", new Vector2(0, 0), tint);

            spriteBatch.DrawString(font1, $"{lives}", new Vector2(45, 0), tint);

            ship1.Draw(spriteBatch);
            if (bulletmove == true)
            {
                for (int i = 0; i < bullet.Count; i++)
                {
                    bullet[i].Draw(spriteBatch);
                    //spriteBatch.Draw(pixel, bullet[i].rect, Color.Lerp(Color.Transparent, Color.Black, .2f));

                }
            }


            if (restart == true)
            {
                spriteBatch.DrawString(font1, "press r to restart", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), tint);

            }

            spriteBatch.DrawString(font1, "score", new Vector2((GraphicsDevice.Viewport.Width -300 ) , 0), tint);
            spriteBatch.DrawString(font1, $"{score.TotalGameTime}", new Vector2(GraphicsDevice.Viewport.Width - 200, 0), tint);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
