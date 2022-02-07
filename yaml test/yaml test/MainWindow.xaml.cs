using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace yaml_test
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Config config = new Config()
            {
                Boolean = false,
                Integer = 28,
                String = "최용국",
                strArr = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" },
                //Area = new List<string> { "1", "2" }

                subcla = new List<subclass>() 
                {
                    new subclass() 
                    {
                        aa = "1",
                        subsubcla = new List<subsubclass>()
                        {
                            new subsubclass()
                            {
                                aaa = "11"  
                            }
                        }
                    },
                    new subclass()
                    {
                        aa = "22",
                        subsubcla = new List<subsubclass>()
                        {
                            new subsubclass()
                            {
                                aaa = "222"
                            }
                        }
                    }
                }
            };

            /*config.subcla = new List<subclass>();
            config.subcla.Add(new subclass()
            {
                aa = "1"
            });*/

            Console.WriteLine("==============================================");
            Console.WriteLine($"{config}");
            FileController.Instance.Serialize("config.yaml", config);
            Console.WriteLine("serializer call");
            Console.WriteLine("==============================================");

            var loadConfig = FileController.Instance.DeSerialize<Config>("config.yaml");
            Console.WriteLine("deserializer call");
            Console.WriteLine($"{loadConfig}");
            Console.WriteLine("==============================================");

            Console.ReadLine();
        }
    }

    public class Config
    {
        public int Integer { get; set; } = 1;
        public string String { get; set; } = "문자열";
        public bool Boolean { get; set; } = true;

        public string[] strArr { get; set; }

        public List<string> Area { get; set; }

        public List<subclass> subcla { get; set; }

        public override string ToString()
        {
            return $"Integer: {Integer}, String: {String}, Boolean: {Boolean}, strArr: {strArr.Length.ToString()}";
        }
    }

    public class subclass
    {
        public string aa { get; set; }
        public List<subsubclass> subsubcla { get; set; }
    }

    public class subsubclass
    {
        public string aaa { get; set; }
    }


}
