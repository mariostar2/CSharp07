using System;

namespace CSharp07
{

    //회원가입에서 이메일 형식이 잘못되었다는 예외
    //직접 만드는 exception
    class InvalidEmailException : Exception
    {
        public int errorCode;                   //나만의 에러코드
        public string email;                    //사용자가 입력한 이메일.
        
        //객체가 생성될 때(=생성자가 호출될 때) 상속하고 있는 Exception의 생성자 중에서
        //string의 하나 받는 생성자를 호출하라고 명시하는 것이다.

        public InvalidEmailException(string msg, int errorCode, string email, string passwordRe) : base(msg)
        {
            this.errorCode = errorCode;
            this.email = email;
        }
    
    }

    class InvalidPasswordException : Exception
    {
        public int  errorCode;
        public string  password;
        public string   passwordRe;
    }

    //회원가입 클래스
    class SignManager
    {
        public void SignIn(string email, string password)
        {
            //실제로는 이메일이 적합한지 여러가지 체크를 할려고 합니다.
            //현재는 그 중 부적합한 부분이 나왔다고 가정한다.
            //throw new InvalidEmailException("이메일 형식이 올바르지 않습니다", 200, email);
            if (email.Length < 4 || email.Length < 12) 
                throw new InvalidEmailException("아이디 혹은 비밀번호의 길이가 짧습니다", 100, email);
            else if (password.Length < 4 || password.Length < 12);
                throw new InvalidPasswordException("비밀번호의 길이가 유효하지 않습니다, ", 100, password);
        }
    }

    internal class Program
    {
        //예외처리
        //=>예측 불가능한 일이 일어나면 프로그램은 종료된다
        static void Main(string[] args)
        {
            if (false)
            {


                int[] array = { 10, 20, 30, 40, 50 };
                //for (int i = 0; i < 10; i++)
                // Console.WriteLine(array[i]);


                //잘못된 인덱스를 통한 배열요소 접근으로
                //배열 객체가 문제에 대한 상세 정보를 Exception 객체에 담아 Main 함수에 던진다.

                //Array가 넘겨준(리턴한) 예외는 Main에서 처리할 방도가 없기 때문에 
                // 그대로 시스템 관리자인 CLR에게 던져준다.
                // CLR은 예외를 발견하고 화면에 출력하면서 프로그램을 종료 시킴.

                //try-catch 문
                // => Main함수으네느 해당 예외를 받아 처리할 준비가 필요하다.try{try{
                // 예외가 일어나는 구간은 try로 감싼다
                try
                {
                    string str = null;


                    for (int i = 0; i < 10; i++)
                        Console.WriteLine(array[i]);

                    Console.WriteLine("출력끝");

                }
                catch (IndexOutOfRangeException e)       //배열 범위를 벗어난 접근 예외
                {
                    Console.WriteLine(e.Message);
                }
                catch (DivideByZeroException e)          //어떠한 값을 0으로 나누러 했을때 일어나는 예외

                {
                    Console.WriteLine(e.Message);
                }
                //만약 이 두가지 이외의 예외가 발생하면
                //처리를 하지 못하기 때문에 CLR에서 종료 시킨다.

                //System.Exception 클래스
                //모든 예외는 해당 클래스를 상속한다(object랑 비슷하다)
                //따라서 어떠한 예외라도 받을수 있지만 섬세한 예외는 불가능하다.
                try
                {
                    int num1 = 10;
                    int num2 = 0;
                    int num3 = num1 / num2;
                    int[] numbers = { 10 };
                    Console.WriteLine(numbers[290]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //throw 키워드
                // = 사용자가 임의의 예외를 발생시킬 수 있다.

                try
                {
                    int number = 10;
                    Console.WriteLine(number);
                    throw new Exception("내가 만든 예외다");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"catch문에 들어오는가 :{e.Message}");

                }
                //try-catch 그리고 finally
                // = 예외가 발생하면 하지 않던 무조건 실행한다.
                try
                {
                    //1:1통신 상태에서 일어날 수 있는 문제.
                    //Network.Connect();            <<아무도 연결하지 않고 있어서 연결에 성공했다고 가정>>
                    //....                          <<여기서 에러가 발생하면>>
                    //Network Disconnect()          <<Disconnect 함수는 호출되지 않는다.

                    //이후 다시는 connect할수 없는  상태가 발생하기도한다.
                }
                catch (Exception e)
                {

                }

                //예외가 발생하던 발생하지 않던 무조건 실행하는 영역임.
                finally
                {
                    // Network.Disconnect() <<try에서 예외가 발생하면 호출되지 않을수 있으니 finally에서 호출한다>>
                }

            }

            //사용자 정의 예외 만들기
            // =.net에는 약 100개의 예외 클래스가 정의되어 있지만
            //내가 원하는 예외가 없을 수도 있다.

            Child child = new Child("연습용",20);
            Console.WriteLine($"name: {child.name}");
            Console.WriteLine($"number{child.number}");

            SignManager signManager = new SignManager();    //회원가입 관리하는 객체.

           
            while(true)
            try
            {
                
                Console.Clear();
                Console.WriteLine("회원 가입 시도");
                Console.WriteLine();

                Console.Write("이메일:");
                string email = Console.ReadLine();
            
                Console.Write("비밀번호:");
                string password = Console.ReadLine();

                Console.Write("비밀번호 재입력:");
                string passwordRe = Console.ReadLine();
        
                signManager.SignIn(email, password);
                Console.WriteLine("회원가입 성공!!");
                break;
            
            }

           
            catch(InvalidEmailException e)
            {
                Console.WriteLine($"[{e.errorCode}] {e.Message} (email : {e.email})");
                    Console.ReadKey();

            }
            
                
        }   
    }

}
