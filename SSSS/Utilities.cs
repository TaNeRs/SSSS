using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.reddit.api;

namespace SSSS {
    public static class Utilities {

        public static double NFoldCrossValidation(int n, Dictionary<string, int> dict) {
            double ret = 0;
            //double cs = 0;

            ////divide the dictionary into n-fold
            //List<Dictionary<string, int>> folds = NFold(n, dict);

            ////do cosine similarity with 
            //for (int i = 0; i < folds.Count; i++) { //i is the test set
            //    for (int j = 0; j < folds.Count; j++) {
            //        if (j != i) { //don't want to eval the same set.

            //        }
            //        else {
            //            continue;
            //        }
            //    }
            //}

            return ret;
        }

        public static void CountUpWords(Post post, Dictionary<string, int> dict) {
            char[] delimit = new char[]{' '};
            int ct = 0;

            string[] words = post.SelfText.Split(delimit, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++) {
                if (dict.TryGetValue(words[i], out ct)) {
                    dict[words[i]] = ct + 1;
                }
                else {
                    dict.Add(words[i], 1);
                }
            }
        }

        public static void CountUpWords(List<Post> list, Dictionary<string, int> dict) {
            foreach (Post p in list) {
                CountUpWords(p, dict);
            }
        }

        public static List<Dictionary<string, int>> NFold(int n, Dictionary<string, int> dict) {
            int min = 0;
            int max = dict.Count;
            int size = (int)Math.Round((decimal)(max / n), 0, MidpointRounding.AwayFromZero);
            int count = 0;
            int fIdx = 0;
            int rIdx;
            List<string> keys = new List<string>();
            Random rand = new Random();          
            List<Dictionary<string, int>> folds = new List<Dictionary<string, int>>();
            Dictionary<string, int> copy = new Dictionary<string, int>(dict);

            //dict size is smaller than fold size.
            if (size == 0) {
                folds.Add(copy);
            }
            else {

                //indexing the keys
                foreach (KeyValuePair<string, int> pair in copy) {
                    keys.Add(pair.Key);
                }

                //fill in the folds
                folds.Add(new Dictionary<string, int>());
                while (copy.Count > 0) {
                    if (count >= size) {
                        if (count == size && fIdx + 1 < n) {
                            folds.Add(new Dictionary<string, int>());
                            fIdx++;
                            count = 0;
                        }
                        else { //handle unevenly divided set.
                            fIdx--; //spread the remaining items to the sets.
                        }
                    }
                    rIdx = rand.Next(min, copy.Count - 1);
                    folds[fIdx].Add(keys[rIdx], copy[keys[rIdx]]); //put the randomly selected key value pair to the fold
                    copy.Remove(keys[rIdx]); //remove the key and key value pair from both copy and key collection.
                    keys.Remove(keys[rIdx]);
                    count++;
                }
            }
            return folds;
        }

        public static double CosineSimilarity(Dictionary<string, int> train, Dictionary<string, int> test) {
            double d1, d2; 
            double ret = -1;
            double n1 = 0;
            int val;

            //calculate the nominator
            foreach (KeyValuePair<string, int> pair in test) {
                if (train.TryGetValue(pair.Key, out val)) {
                    n1 += pair.Value * val;
                }
            }

            //calculate the denominator
            d1 = SqRtOfSumOfSq(test);
            d2 = SqRtOfSumOfSq(train);

            //calculate cosine similarity
            ret = n1 / (d1 * d2);

            return ret;
        }

        private static double SqRtOfSumOfSq(Dictionary<string, int> dict) {
            double val = 0;
            double tmp;
            
            if (dict.Count > 0) {
                foreach (KeyValuePair<string, int> pair in dict) {
                    tmp = Math.Pow(pair.Value, 2);
                    val += tmp;
                }
                val = Math.Sqrt(val);
            }
            return val;
        }
    }
}
