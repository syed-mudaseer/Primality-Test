bool IsPrime(int n)
    {
	if (n < 2 || n % 2 == 0) return false; // n<2 or n is even
		
        if (n == 2 || n == 3) return true; // corner cases
		
        int s = n - 1;
        while (s % 2 == 0)  s >>= 1;
 
        Random r = new Random();
		int k = 40; // optimal number of rounds for this test is 40
		
        for (int i = 0; i < k; i++)
        {
            int a = r.Next(2, n - 1); // pick a random number between 2 and n-1
            int d = s;
			
            long x = 1;
			
            for (int j = 0; j < d; j++)  x = (x * a) % n;
            while (d != n - 1 && x != 1 && x != n - 1) // check till d becomes n-1 and xis eith 1 or n-1
            {
                x = (x * x) % n;
                d *= 2;
            }
 
            if (x != n - 1 && d % 2 == 0) return false;
        }
        return true;
    }

Resources:
https://math.mit.edu/research/highschool/primes/materials/2014/Narayanan.pdf
https://stackoverflow.com/questions/6325576/how-many-iterations-of-rabin-miller-should-i-use-for-cryptographic-safe-primes
https://www.geeksforgeeks.org/primality-test-set-3-miller-rabin/
https://titanwolf.org/Network/Articles/Article?AID=524959e6-9034-46d0-8bf9-a68e18e1aab4#gsc.tab=0