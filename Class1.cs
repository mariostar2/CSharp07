using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp07
{
    internal class Base
    {
        public string name;
        
        //빈 생성자
        public Base()
        {
            Console.WriteLine("Base의 빈 생성자");
        }
        
        public Base(string name)
        {
            this.name = name;
            Console.WriteLine("Base의 string을 받는 생성자");
        }       
    }

    class Child : Base
    {
        public int number;

        //객체는 생성될 때 (인스턴스) 무조건 생성자가 불리게 되어있다.
        //만약에 생성자를 정의(명시)하지 않는 다면 컴파일러가 자동으로 반 기본 생성자를 만들어낸다.
        
        //Child는 Base를 상속하고 있다
        //Child의 생성자가 불릴때, 그보다 먼저 Base의 생성자가 불려야한다.
        //만약 아무런 명시를 하지 않으면 Base의 기본 생성자가 자동으로 불린다.

        //아래는 string, int를 받느 Child의 생성자가 호출될 때
        // 부모 클래스인 Base의 string을 받는 생성자를 호출하라는 의미다.
        public Child(string name, int number) : base(name)
        {
            this.number = number;
            Console.WriteLine("Child의 int를 받는 생성자");
            
        }
    }
}
