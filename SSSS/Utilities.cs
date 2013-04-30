using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using com.reddit.api;

namespace SSSS {
    public static class Utilities {
        #region CONSTANTS

        //Constants for the column that shows if there is a link or image in the post.
        public const string LINK_OR_IMAGE = "LinkOrImage"; //!!! This is the header of one of the word column.  What if this word is in a post?  Need to take care of this in the future.
        public const string YES = "Yes";
        public const string NO = "No";

        #endregion

        #region Public Methods

        public static void CountUpWords(Post post, Dictionary<string, int> dict) {
            char[] delimit = new char[] { ' ' };
            int ct = 0;
            string[] words = new string[0];

            if (IsLinkOrImage(post)) {
                if (string.IsNullOrEmpty(post.SelfText)) { //an image
                    return;
                } else { //is a link
                    words = post.SelfText.Split(delimit, StringSplitOptions.RemoveEmptyEntries);
                }
                //WebClient client = new WebClient();
                //string htmlCode = client.DownloadString(post.Url);
                //words = htmlCode.Split(delimit, StringSplitOptions.RemoveEmptyEntries);
            }
            else {
                words = post.SelfText.Split(delimit, StringSplitOptions.RemoveEmptyEntries);
            }

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

        public static string[][] GenerateCountVectorTable(List<Post> list) {
            string[][] ret = null;
            Dictionary<string, int> dict = new Dictionary<string,int>();
            int numOfPosts = list.Count, numOfWords, idx = 0;

            //get the number of post and the number of different words from all the posts
            foreach (Post p in list) {
                CountUpWords(p, dict);
            }
            numOfWords = dict.Count;

            if (numOfPosts > 0 && numOfWords > 0) {

                //init the string array.  The [0] position is the name of the row or column
                ret = new string[numOfWords + 2][];  //include a column for LINK_OR_IMAGE
                for (int i = 0; i < ret.Length; i++) {
                    ret[i] = new string[numOfPosts + 1];
                    for (int j = 0; j < ret[i].Length; j++) {
                        if (i != 0 && j != 0) { //The top left corner should remain null.
                            ret[i][j] = "0"; //init with "0";
                        }
                    }
                }

                //fill out the names of the rows and columns
                ret[1][0] = LINK_OR_IMAGE; //The first column tells if it is a link or image
                idx = 2;
                foreach (KeyValuePair<string, int> pair in dict) { //columns
                    ret[idx][0] = pair.Key;
                    idx++;
                }
                idx = 1;
                foreach (Post p in list) { //rows
                    ret[0][idx] = p.Name;
                    idx++;
                }

                //insert the word count and link or image check into the table;
                foreach (Post p in list) {

                    //check if there is a link or image in p
                    if (IsLinkOrImage(p)) {
                        SetTableValue(ret, p.Name, LINK_OR_IMAGE, YES);
                    }
                    else {
                        SetTableValue(ret, p.Name, LINK_OR_IMAGE, NO);
                    }

                    //count up words in p
                    dict.Clear();
                    CountUpWords(p, dict);
                    foreach (KeyValuePair<string, int> pair in dict) {
                        if (SetTableValue(ret, p.Name, pair.Key, pair.Value.ToString())) {
                            //success
                        }
                        else { /*fail*/ }
                    }
                }
            }
            else { /*return*/ }

            return ret;
        }

        public static string GetTableValue(string[][] strArray, string postName, string word) { //row=postName, col=word

            bool isDone = false;
            string ret = null;
            for (int i = 0; i < strArray.Length; i++) {
                if (strArray[i][0] != null && strArray[i][0].ToString().Equals(word)) {
                    for (int j = 0; j < strArray[i].Length; j++) {
                        if (strArray[0][j] != null && strArray[0][j].ToString().Equals(postName)) {
                            if (!string.IsNullOrEmpty(strArray[i][j])) {
                                //ret = Convert.ToInt32(strArray[i][j]);
                                ret = strArray[i][j].ToString();
                            }
                            isDone = true;
                            break;
                        }
                    }
                    if (isDone) {
                        break;
                    }
                }
            }
            return ret;
        }

        public static bool IsLinkOrImage(Post post) {
            if (post.IsSelf)
                return false;
            return true;
        }

        //This function randomly divide the dictionary into n folds.
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

        public static double CosineSimilarity(string[] words, string[] train, string[] test) {
            double ret = -1;
            int trInt, teInt;
            Dictionary<string, int> tr = new Dictionary<string, int>();
            Dictionary<string, int> te = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++) {
                if (words[i] != null) {
                    if (Int32.TryParse(train[i], out trInt) && Int32.TryParse(test[i], out teInt)) {
                        tr.Add(words[i], trInt);
                        te.Add(words[i], teInt);
                    }
                }
            }

            if (tr.Count > 0 && te.Count > 0) {
                ret = CosineSimilarity(tr, te);
            }
            return ret;
        }

        public static double PrecisionUsingCosineSimilarity(string[][] arr, Post testPost, double poolSize, double threshold) {
            //const double poolSize = 2;
            //const double threshold = 0.5;
            double count = 0;
            double ret = -1, val;
            string[] row = null;
            string[] posts = null;
            string[] words = null;
            string[] test = new string[arr.Length];
            double[] cs = new double[arr[0].Length];
            Dictionary<string, int> te = new Dictionary<string, int>();

            //get the word count of each word in the post.
            CountUpWords(testPost, te);
            foreach (KeyValuePair<string, int> pair in te) {
                for (int i = 0; i < arr.Length; i++) {
                    if (!string.IsNullOrEmpty(arr[i][0]) && arr[i][0].Equals(pair.Key)) { 
                        test[i] = pair.Value.ToString();
                        break;
                    }
                }
            }

            //find the cosine similarity between the posts in the vector table and the test post
            words = getRow(arr, 0);
            for (int i = 0; i < arr[0].Length; i++) {
                if (!string.IsNullOrEmpty(arr[0][i])) { //check if there is a post
                    row = getRow(arr, i);
                    val = CosineSimilarity(words, row, test);
                    cs[i] = val;
                }
                else {
                    cs[i] = 0; //default to 0
                }
            }

            //sort the cosine similarity values
            posts = new string[arr[0].Length];
            Array.Copy(arr[0], posts, arr[0].Length);
            ReverseComparer rc = new ReverseComparer();
            Array.Sort(cs, posts, rc);

            //get the precision value = relevent posts out of top posts
            for (int i = 0; i < poolSize; i++) {
                if (!string.IsNullOrEmpty(posts[i]) && cs[i] > threshold) { //It is a post and cs is > threshold
                    count++;
                }
            }
            ret = count / poolSize;

            return ret;
        }


        public static double PrecisionUsingJaccardSimilarity(string[][] arr, Post testPost, double poolSize, double threshold)
        {
            double count = 0;
            double ret = -1;
            string[] row = null;
            string[] posts = null;
            string[] words = null;
            string[] test = new string[arr.Length];
            double[] js = new double[arr[0].Length];

            Dictionary<string, int> te = new Dictionary<string, int>();

            //get the word count of each word in the post.
            CountUpWords(testPost, te);
            foreach (KeyValuePair<string, int> pair in te)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i][0]) && arr[i][0].Equals(pair.Key))
                    {
                        test[i] = pair.Value.ToString();
                        break;
                    }
                }
            }

            //find the Jaccard similarity between the current training post and the test post
            words = getRow(arr, 0);
            for (int i = 0; i < arr[0].Length; i++)
            {
                if (!string.IsNullOrEmpty(arr[0][i]))
                { //check if there is a post
                    row = getRow(arr, i);
                    js[i] = JaccardSimilarity(words, row, test);
                    Console.WriteLine("Finished checking one row. Jaccard coefficient is: " + js[i]);

                }
                else
                {
                    js[i] = 0; //default to 0
                }
            }

            //sort the Jaccard similarity values
            posts = new string[arr[0].Length];
            Array.Copy(arr[0], posts, arr[0].Length);
            ReverseComparer rc = new ReverseComparer();
            Array.Sort(js, posts, rc);

            //get the precision value = relevent posts out of top posts
            for (int i = 0; i < poolSize; i++)
            {
                if (!string.IsNullOrEmpty(posts[i]) && js[i] > threshold)
                { //It is a post and cs is > threshold
                    count++;
                }
            }
            ret = count / poolSize;

            return ret;
        }

        public static double JaccardSimilarity(string[] words, string[] train, string[] test)
        {
            double ret = -1;
            int trInt, teInt;
            Dictionary<string, int> tr = new Dictionary<string, int>();
            Dictionary<string, int> te = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != null)
                {
                    Console.WriteLine("adding this word: " + words[i]);

                    if (Int32.TryParse(train[i], out trInt) && Int32.TryParse(test[i], out teInt))
                    {
                        tr.Add(words[i], trInt);
                        te.Add(words[i], teInt);
                    }
                }
            }

            if (tr.Count > 0 && te.Count > 0)
            {
                ret = JaccardSimilarity(tr, te);
            }
            return ret;
        }


        private static string[] getRow(string[][] ar, int row) {
            string[] ret = new string[ar.Length];

            for (int i = 0; i < ar.Length; i++) {
                ret[i] = ar[i][row];
            }
            return ret;
        }

        public static void PrintTableToOutput(string[][] arr) {
            for (int i = 0; i < arr.Length; i++) {
                for (int j = 0; j < arr[i].Length; j++) {
                    if (arr[i][j] == null) {
                        System.Console.Write("| null ");
                    }
                    else {
                        System.Console.Write("| " + arr[i][j] + " ");
                    }
                }
                System.Console.WriteLine();
            }
        }

        #endregion

        #region Private Methods

        private static bool SetTableValue(string[][] strArray, string row, string col, string val) {
            bool isDone = false;
            for (int i = 0; i < strArray.Length; i++) {
                if (strArray[i][0] != null && strArray[i][0].ToString().Equals(col)) {
                    for (int j = 0; j < strArray[i].Length; j++) {
                        if (strArray[0][j] != null && strArray[0][j].ToString().Equals(row)) {
                            strArray[i][j] = val;
                            isDone = true;
                            break;
                        }
                    }
                    if (isDone) {
                        break;
                    }
                }
            }
            return isDone;
        }

        private static double JaccardSimilarity(Dictionary<string, int> train, Dictionary<string, int> test)
        {
            double d1 = 0;
            double ret = -1;
            double n1 = 0;
            int val;

            //calculate the numerator, interesection of training and test data
            foreach (KeyValuePair<string, int> pair in test)
            {
                if (train.TryGetValue(pair.Key, out val))
                {
                    if (val > 0 && pair.Value > 0)
                    {
                        Console.WriteLine("Intersecting value is: " + pair.Key + " " + pair.Value);
                        n1++;
                    }
                }
            }

            Dictionary<string, int>[] dictionaries = new Dictionary<string, int>[] { train, test };

            //calculate the denominator
            var joinedDictionary = new Dictionary<string, int>();
            foreach (var dict in dictionaries)
                foreach (var x in dict)
                    joinedDictionary[x.Key] = x.Value;

            /*            var joinedDictionary = dictionaries.SelectMany(dict => dict)
                                     .ToLookup(pair => pair.Key, pair => pair.Value)
                                     .ToDictionary(group => group.Key, group => group.First()); */

            d1 = joinedDictionary.Count();

            Console.WriteLine("d1 is " + d1);
            foreach (var entry in joinedDictionary)
                Console.WriteLine("[{0} {1}]", entry.Key, entry.Value);
            Console.WriteLine("that's all, folks");

            //calculate Jaccard similarity
            ret = n1 / d1;
            Console.WriteLine("Jaccard's coefficient is: " + ret);
            return ret;

        }


        private static double CosineSimilarity(Dictionary<string, int> train, Dictionary<string, int> test) {
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

        #endregion
    }

    public class ReverseComparer : IComparer<double> {
        public int Compare(double x, double y) {
            // Compare y and x in reverse order. 
            return y.CompareTo(x);
        }
    }
}
