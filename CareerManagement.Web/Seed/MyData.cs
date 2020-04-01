using CareerManagement.Data;
using CareerManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerManagement.Web.Seed
{
    public class MyData
    {
        public MyData(DataContext db)
        {
            this.db = db;
        }

        public void Clear()
        {
            var user = this.db.Users
                .Where(u => u.Username == "bbonkr")
                .FirstOrDefault();

            if (user != null)
            {
                this.db.Users.Remove(user);
                this.db.SaveChanges();
            }
        }

        public void Seed()
        {
            this.db.Users.Add(new User
            {
                Name = "구본철",
                Username = "bbonkr",
                Email = "bbon@bbon.kr",
                Logins = new List<UserLogin> {
                    new UserLogin{
                        ExpiredAt= DateTimeOffset.MaxValue,
                        IsLocked=false,
                        LockedAt = null,
                        Provider= "Local",
                        RetryCount=0,
                        Secret=""
                    }
                },
                Profile = new Profile
                {
                    Bio = $@"
12년 근무중 .NET 응용프로그램 개발팀으로 8년, 기술연구소에서 4년 근무했습니다.

백엔드는 ASP.NET Core, 모바일 응용프로그램은 Android /iOS 로 접근하기 보다 Xamarin.Forms 로 크로스 플랫폼으로 진행하는 것을 선호합니다.

최근 Node.js 백엔드와 React 프론트엔드에 관심을 갖고 있습니다.

업무진행은 능동적으로 처리하는 것을 선호하며, 대화가 잘 되는 팀과 함께 일을 진행해보고 싶습니다.

서비스 기획이 준비되고, 해당 서비스의 분석, 설계, 구현이 필요한 팀을 찾고 있습니다. 최소 기능 제품으로 시작해서 마지막까지 팀원과 함게 하고 싶습니다.
",
                    /*

                     */
                    Links = new List<ProfileLink>
                    {
                        new ProfileLink
                        {
                            Link = new Link
                            {
                                Title="GitHub",
                                Url="https://github.com/bbonkr",
                                Target="_blank"
                            }
                        },
                        new ProfileLink
                        {
                            Link = new Link
                            {
                                Title="Blog",
                                Url="https://bbon.kr",
                                Target="_blank"
                            }
                        }
                    }
                },
                Educations = new List<Education>
                {
                    new Education
                    {
                        Title= "한국방송통신대학교",
                        Description="컴퓨터과학",
                        State="입학",
                        Period=  "2008-03"
                    },
                    new Education
                    {
                        Title= "한국방송통신대학교",
                        Description="컴퓨터과학",
                        State="졸업",
                        Period=  "2012-02"
                    }
                },
                Careers = new List<Career>
                {
                    new Career
                    {
                        Title="(주)아이디노",
                        Description="솔루션개발부",
                        Period="2007-03",
                        State="입사",
                    },
                    new Career
                    {
                        Title="(주)아이디노",
                        Description="기술연구소",
                        Period="2019-03",
                        State="퇴사",
                    }
                },
                Portfolios = new List<Portfolio> {
                    new Portfolio
                    {
                        Title="Blog Service #2",
                        Descriptoin="마크다운으로 글을 작성하는 블로그 서비스입니다. Nodejs 백엔드와 React 프론트엔드를 타입스크립트로 작성했습니다.",
                        Period="2019-10",
                        State="완료",
                        Features=new List<PortfolioFeature>
                        {
                            new PortfolioFeature
                            {
                               Content="Nodejs Backend",
                            },
                            new PortfolioFeature
                            {
                               Content="express.js",
                            },
                              new PortfolioFeature
                            {
                               Content="passport.js",
                            },
                            new PortfolioFeature
                            {
                                Content="Sequelize.js",
                            },
                            new PortfolioFeature
                            {
                                Content="React.js",
                            },
                            new PortfolioFeature
                            {
                                Content="Next.js",
                            },
                            new PortfolioFeature
                            {               
                                Content="Styled Component",
                            },
                            new PortfolioFeature
                            {
                                Content="Redux",
                            },
                            new PortfolioFeature
                            {
                                  Content="Redux-saga",
                            },
                        },
                        Links=new List<PortfolioLink>
                        {
                            new PortfolioLink
                            {
                                Link = new Link
                                {
                                    Title="데모사이트",
                                    Url="https://blog-service.bbon.me/",
                                    Icon="home",
                                    Target="_blank"
                                },
                            },
                            new PortfolioLink
                            {  
                                Link = new Link
                                {
                                    Title="GitHub: Blog service backend",
                                    Url="https://github.com/bbonkr/blog-node-backend",
                                    Icon="github",
                                    Target="_blank"
                                },
                            },
                            new PortfolioLink
                            {
                                Link = new Link
                                {
                                    Title="GitHub: Blog service frontend",
                                    Url="https://github.com/bbonkr/react-blog-frontend",
                                    Icon="home",
                                    Target="_blank"
                                }
                            }
                        }
                    }
                },
            });
        }

        private readonly DataContext db;
    }
}
