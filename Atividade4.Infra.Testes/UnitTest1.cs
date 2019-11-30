using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Atividade04.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atividade4.Infra.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldGetDatabase()
        {
            var database = Helper.GetDatabase();
            Assert.IsTrue(database != null);
        }

        [TestMethod]
        public void ShouldGetCollection()
        {
            var collection = Helper.GetCollection<Blog>();
            Assert.IsTrue(collection != null);
        }

        [TestMethod]
        public void ShouldInsertOneAsync()
        {
            var tasks = new List<Task>();

            // insere
            tasks.Add(Helper.InsertOneAsync(new Blog { Description = "test blog - lucas paga cuca" }));
            tasks.Add(Helper.InsertOneAsync(new User { Login = "eliton.gadotti", Name = "Eliton", Password = "thatsallfolks" }));

            Task.WaitAll(tasks.ToArray());

            // confere
            //...
        }

        [TestMethod]
        public void ShouldReplaceOneAsync()
        {
            var @object = new User { Login = "eliton.gadotti", Name = "Eliton", Password = "noOneCares" };
            Expression<Func<User, bool>> filterExpression = x => x.Login == "eliton.gadotti";

            var task = Helper.ReplaceOneAsync(filterExpression, @object);
            Task.WaitAll(task);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoadBlog1()
        {
            var user1 = new User { Login = "eliton", Name = "Eliton Gadotti", Password = "123", Role = Atividade04.Domain.Enum.UserRole.Owner };
            var postsBlog1 = new List<Post>();
            var sectionsBlog1 = new List<Section>();
            var subsectionsBlog1 = new List<Subsection>();

            subsectionsBlog1.Add(new Subsection
            {
                Content = @"Pela primeira vez desde que foi eleita para a Presidência do Uruguai, há 15 anos, a coalizão Frente Ampla, 
formada pelo ex-presidente José 'Pepe' Mujica e pelo atual presidente Tabaré Vázquez, corre o risco de perder o poder no país.",
                Title = ""
            });

            subsectionsBlog1.Add(new Subsection
            {
                Content = @"A distância entre os dois presidenciáveis apareceu um pouco maior na pesquisa Metrocall Contact Center, publicada pelo jornal 
uruguaio El País, na quinta-feira (21), com 52% para o opositor e 41% para o candidato da situação. Setores governistas observam que o 
índice de indecisos, em torno de 4% a 6%, ainda é alto, mas admitem as dificuldades.",
                Title = ""
            });

            sectionsBlog1.Add(new Section
            {
                Title = "",
                Content = @"Pesquisas de opinião apontam vantagem para o candidato da oposição Luis Lacalle Pou, do Partido Nacional, 
em relação ao presidenciável governista Daniel Martínez, da Frente Ampla. Um levantamento da empresa Factum 
divulgado na quarta-feira (20/11), quatro dias antes do segundo turno da eleição neste domingo, indicou que Lacalle 
Pou contaria com 51% da intenção de votos e Martínez, com 43%.",
                Order = 1,
                Subsections = subsectionsBlog1
            });

            postsBlog1.Add(new Post
            {
                Date = DateTime.Today.Date,
                Sections = sectionsBlog1,
                Title = "Por que grupo de Mujica corre risco de perder o poder no Uruguai, após 15 anos"
            });

            var blog1 = new Blog
            {
                Description = "BBC Blog",
                Posts = postsBlog1,
                Title = "Blog da BBC. Mantenha-se informado",
                User = user1
            };
            try
            {
                var task = Helper.InsertOneAsync(blog1);
                Task.WaitAll(task);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [TestMethod]
        public void LoadBlog2()
        {
            var user1 = new User { Login = "lucas", Name = "Lucas Fischer", Password = "123", Role = Atividade04.Domain.Enum.UserRole.Owner };
            var postsBlog1 = new List<Post>();
            var sectionsBlog1 = new List<Section>();
            var subsectionsBlog1 = new List<Subsection>();

            subsectionsBlog1.Add(new Subsection
            {
                Content = @"Na sessão da véspera, em que o STF começou a julgar se órgãos de fiscalização como a Receita Federal, o antigo Coaf (Conselho de Controle de Atividades Financeiras) e o Banco Central podem repassar informações sigilosas para o Ministério Público sem prévia autorização judicial, Toffoli considerou constitucional o repasse de informações pelo antigo Coaf.",
                Title = ""
            });

            subsectionsBlog1.Add(new Subsection
            {
                Content = @"Flávio Bolsonaro é investigado por suspeitas de desvio de recursos de seu ex-gabinete de deputado estadual no Rio de Janeiro, apuração que foi alimentada por dados do antigo Coaf, recentemente renomeado para UIF (Unidade de Inteligência Financeira). Em julho, Toffoli aceitou seu pedido para suspender a investigação e todos os casos similares no país até que o STF julgasse a constitucionalidade desses compartilhamentos por órgãos de controle.",
                Title = ""
            });

            sectionsBlog1.Add(new Section
            {
                Title = "",
                Content = @"O presidente do Supremo Tribunal Federal, Dias Toffoli, esclareceu nesta quinta-feira (21/11) que votou para derrubar sua própria liminar, a qual em julho havia paralisado centenas de investigações e processos no Brasil a pedido do senador Flávio Bolsonaro (PSL-RJ).",
                Order = 1,
                Subsections = subsectionsBlog1
            });

            postsBlog1.Add(new Post
            {
                Date = DateTime.Today.Date,
                Sections = sectionsBlog1,
                Title = "Toffoli vota contra sua própria liminar que havia parado investigação sobre Flávio Bolsonaro"
            });

            var blog1 = new Blog
            {
                Description = "Lucas Blog",
                Posts = postsBlog1,
                Title = "Blog do Lucas (do morenas azuis)",
                User = user1
            };
            try
            {
                var task = Helper.InsertOneAsync(blog1);
                Task.WaitAll(task);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [TestMethod]
        public void PublishBlog1()
        {
            var post = new Post
            {
                Title = "Sobre mim",
                Date = DateTime.Today.AddDays(-7).Date,
                Sections = new List<Section>
                {
                    new Section
                    {
                        Content = "",
                        Order = 2,
                        Title = "",
                        Subsections = new List<Subsection>
                        {
                            new Subsection
                            {
                                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                                Title = "Lorem ipsum dolor sit amet"
                            }
                        }
                    }
                }
            };

            var blog = Helper.GetFiltered<Blog>(b => b.User.Login == "eliton").FirstOrDefault();
            blog.Posts.Add(post);
            var task = Helper.ReplaceOneAsync(b => b.Id.Equals(blog.Id), blog);

            Task.WaitAll(task);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PublicBlogRafael()
        {
            var post = new Post
            {
                Title = "Sobre mim - Rafael",
                Date = DateTime.Today.AddDays(-7).Date,
                Sections = new List<Section>
                {
                    new Section
                    {
                        Content = "",
                        Order = 2,
                        Title = "",
                        Subsections = new List<Subsection>
                        {
                            new Subsection
                            {
                                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                                Title = "Lorem ipsum dolor sit amet"
                            }
                        }
                    }
                }
            };

            var blog = Helper.GetFiltered<Blog>(b => b.User.Login == "rafael.professor").FirstOrDefault();
            if (blog.Posts == null)
            {
                blog.Posts = new List<Post> { post };
            } else
            {
                blog.Posts.Add(post);
            }
            
            var task = Helper.ReplaceOneAsync(b => b.Id.Equals(blog.Id), blog);

            Task.WaitAll(task);
            Assert.IsTrue(true);
        }
    }
}
