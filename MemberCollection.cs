using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrarySystem
{
    class MemberCollection
    {


		
		private int count; //the number of key-and-value pairs currently stored in the hashtable
		private int buckets=1000; //number of buckets
		private int[] table; //a int array contains integer keys
		private Member[] members;//a Member array contains member objects one-to-one corresponding with keys.
		private const int empty = -10000; //an empty bucket
		private const int deleted = -9999;  //a bucket where a key-and-value pari was deleted



		// constructor
		public MemberCollection()
		{
			
			count = 0;
			members = new Member[buckets];
			table = new int[buckets];
			for (int i = 0; i < buckets; i++)
            {
				table[i] = empty;
				members[i] = new Member();
			}		
			
		}

		

		public int Count
		{
			get { return count; }
		}

		public int Capacity
		{
			get { return buckets; }
			set { buckets = Capacity; }
		}


		/* pre:  true
		* post: return the bucket where the key is stored
		*		 if the given key in the hashtable;
		*		 otherwise, return -1.
		*/
		public void Insert(Member member)
		{
			string name = member.FirstName + member.LastName;
			byte[] arr = Encoding.ASCII.GetBytes(name);
			int memberKey = 0;
			foreach (byte e in arr)
			{
				memberKey += e;
			}

			// check the pre-condition
			if ((Count < table.Length) && (Search(memberKey) == -1))
			{
				int bucket = Find_Insertion_Bucket(memberKey);
				table[bucket] = bucket;
				members[bucket] = member;
				count++;
			}
			else
				Console.WriteLine("This memeber is already existing.");
		}


		public int FindAMember(string name)
		{

			byte[] arr = Encoding.ASCII.GetBytes(name);
			int memberKey = 0;
			foreach (byte e in arr)
			{
				memberKey += e;
			}
			int result;

			if (Search(memberKey) == -1)
			{
				return -1;
			}
			else
			{
				result = Search(memberKey);				
				return result;
			}
		}

        public Member GetAMemberInfo(string name)
        {

            int result = FindAMember(name);

            return members[result];

        }

        public void BorrowingMemberList()
        {
			int amount = 0;
			for (int i=0; i < members.Length; i++)
            {
				
				if (members[i].isBorrowing==true)
                {
					Console.Write(" " + members[i].FirstName+" "+members[i].LastName + "; ");
					amount++;
                }
            }

			Console.WriteLine($"\n{amount} memebrs are currently borrowing tools.");
		}

		public string SearchPassword(string name)
		{
			int result = FindAMember(name);

			string password;
			if (result == -1)
			{
				return "Not an existing member.";
			}
			else
			{
				password = members[result].Password;
				return password;
			}
		}


		public string SearchPhoneNumber(string name)
        {			
			int result= FindAMember(name);

			string phoneNumber;
			if(result == -1)
            {
				return "Not existing";
            }
            else
            {	
				phoneNumber=members[result].PhoneNumber;
				return phoneNumber;
			}
		}

		public string RemoveAMember(string name)
        {
			int result = FindAMember(name);
			if (result == -1)
			{
				return "Not an existing member.";
			}
			else
			{
				members[result] = new Member();
				Delete(result);
				
				return "Successfully Removed.";
			}
		}

		

		/* pre:  the hashtable is not full
		 * post: return the bucket for inserting the key
		 */
		private int Find_Insertion_Bucket(int key)
		{
			int bucket = Hashing(key);
			int i = 0;
			int offset = 0;
			while ((i < buckets) &&
				(table[(bucket + offset) % buckets] != empty) &&
				(table[(bucket + offset) % buckets] != deleted))
			//++offset; //linear probing
			{
				i++;
				offset = i * i;
			}
			return (offset + bucket) % buckets;
		}

		/* pre:  true
		* post: all the elements in the hashtable have been removed
		*/
		public void Clear()
		{
			count = 0;
			for (int i = 0; i < buckets; i++)
            {
				table[i] = empty;
				members[i] = new Member();
			}
				
		}

		

		/* pre:  true
		 * post: return the bucket where the key is stored
		 *		 if the given key in the hashtable;
		 *		 otherwise, return -1.
		 */
		public int Search(int key)
		{
			int bucket = Hashing(key);

			int i = 0;
			int offset = 0;
			while ((i < buckets) &&
				(table[(bucket + offset) % buckets] != key) &&
				(table[(bucket + offset) % buckets] != empty))
			//offset++;// linear probing
			{

				i++;
				offset = i * i; //qudratic probing
			}
			if (table[(bucket + offset) % buckets] == key)
				return (offset + bucket) % buckets;
			else
				return -1;
		}

		/* pre:  nil
		 * post: the given key has been removed from the hashtable if the given key is in the hashtable
		*/
		public void Delete(int key)
		{
			int bucket = Search(key);
			if (bucket != 1)
			{
				table[bucket] = deleted;
				count--;
			}
			else
				Console.WriteLine("The given key is not in the hashtable");
		}


		/* pre:  key>=0
		 * post: return the bucket (location) for the given key
		 */
		private int Hashing(int key)
		{			

			return (key % buckets);

		}


		/* pre:  nil
		 * post: print all the elements in the hashtable
		*/

		public void Print()
		{
			for (int i = 0; i < buckets; i++)
			{
				if ((table[i] == empty) || (table[i] == deleted))
                {
					//Console.Write(" __ ");
				}

				else
					Console.Write(" " + members[i].FirstName+" "+ members[i].LastName + ", ");
			}
			
			Console.WriteLine();
			Console.WriteLine(count);
			Console.WriteLine();

		}
	}
}
