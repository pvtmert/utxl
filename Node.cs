using System;

namespace UTXL
{
	public class Node
	{
		public Node next;
		/*
		{
			get { return this.next; }
			set { this.next = value; }
		}
		*/
		public Node prev;
		/*
		{
			get { return this.prev; }
			set { this.prev = value; }
		}*/
		public string data;
		/*
		{
			get { return this.data; }
			set { this.data = value; }
		}
		*/
		public Node ()
		{
			next = null;
			prev = null;
			data = null;
		}
		public Node (string data)
		{
			this.data = data;
			next = null;
			prev = null;
		}
		public Node(string data, Node next, Node prev)
		{
			this.next = next;
			this.prev = prev;
			this.data = data;
		}
		public void addT(Node n)
		{
			Node t = tail ();
			t.next = n;
			n.prev = this;
			return;
		}
		public void addH(Node n)
		{
			Node t = head ();
			t.prev = n;
			n.next = this;
			return;
		}
		public Node tail()
		{
			Node t = this;
			while (t.next != null)
				t = t.next;
			return t;
		}
		public Node head()
		{
			Node t = this;
			while (t.prev != null)
				t = t.prev;
			return t;
		}
		public void add(Node n)
		{
			this.next = n;
			n.prev = this;
			return;
		}
		/*
		public void before()
		{
			if (this.prev != null)
				this = this.prev;
			return;
		}
		public void after()
		{
			if (this.next != null)
				this = this.next;
			return;
		}
		*/
		public void _debug()
		{
			Node t = head ();
			while (t != null)
			{
				Console.Write( ((t == this)?'>':' ') );
				Console.WriteLine (t.data.Replace ('\n', '?'));
				t = t.next;
			}
			Console.WriteLine ();
		}
		public void rmt()
		{
			return;
			Node t = this;
			if (t.next != null)
				if (t.next.next != null)
					t.next.rmt ();
				else
					t.next = null;
			return;
		}
		public void rmh()
		{
			return;
			Node t = this;
			if (t.prev != null)
				if (t.prev.prev != null)
					t.prev.rmh ();
				else
					t.prev = null;
			return;
		}
	}
}

