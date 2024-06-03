namespace Egz
{
    public class PasswordCracker
    {
        public Password passwd;
        public string cracked_password = "\0";
        public PasswordCracker(Password pw)
        {
            passwd = pw;
        }
        public void BruteForce(int jump, int start)
        {
            int arrsize = 20;
            char[] current_guess = { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' };
            current_guess[arrsize - 1] = '0';
            string guess = "";
            int i = 1; //parodo ties kelintu simboliu (nuo galo) yra dirbama siuo metu 
            int j = 1; //parodo kiek netusciu simboliuo siuo metu yra
            while ((int)current_guess[0] <= 122)
            {
                guess = "";
                guess += current_guess[arrsize - j];
                for (int k = j - 1; k >= 1; k--)
                {
                    guess += current_guess[arrsize - k];
                }

                if (passwd.CheckHash(guess)) { cracked_password = guess; break; }
                if ((int)current_guess[arrsize - i] > 122)
                {
                    while ((int)current_guess[arrsize - i] > 122)
                    {
                        current_guess[arrsize - i] = (char)(47 + start);
                        i++;
                        if ((int)current_guess[arrsize - i] == '\0') current_guess[arrsize - i] = (char)(47 + start);
                        else current_guess[arrsize - i] = (char)((int)current_guess[arrsize - i] + jump);
                        if (i > j) j = i;
                    }
                    i = 1;
                }
                else current_guess[arrsize - i] = (char)((int)current_guess[arrsize - i] + jump);
            }
        }
    }
}
