namespace TextGame
{
    internal class Equipment
    {
        // 엑세스, 권능이라 부르고 세 종류가 존재. 딜리터, 메모라이즈, 부산물
        public string Access { get; set; } = "";
        public string WeaponName { get; set; } = "";
        public string ArmorName { get; set; } = "";

        public string[] Accessories { get; } = { "", "", "" };
    }
}
