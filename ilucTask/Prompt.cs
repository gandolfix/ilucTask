using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ilucTask
{
	class Prompt
	{
		readonly Tarefas ts;
		Tarefa tarefa, tarefaRef;
		DateTime date;
		public Prompt(Tarefas tasks)
		{
			tarefa = new Tarefa();
			ts = tasks;
			Console.OutputEncoding = System.Text.Encoding.Unicode;
			date = DateTime.Now;
		}
		public void DrwHeader()
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;

			Console.Write((char)9484);
			for (int i = 0; i < ts.getColCount(); i++)
			{
				for (int j = 0; j < ts.getColSize(i); j++)
				{
					Console.Write((char)9472);
				}
				Console.Write((char)9516);
			}
			Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
			Console.WriteLine((char)9488);
			Console.Write((char)9474);

			for (int i = 0; i < ts.getColCount(); i++)
			{
				if (ts.getColText(i).Length > ts.getColSize(i))
				{
					string trim = ts.getColText(i);
					Console.Write(trim.Substring(0, ts.getColSize(i)));
				}
				else
				{
					int spaces = ts.getColSize(i) - ts.getColText(i).Length;
					Console.Write(ts.getColText(i));
					for (int j = 0; j < spaces; j++)
					{
						Console.Write(" ");
					}
				}
				Console.Write((char)9474);
			}
			Console.WriteLine("");
			Console.ResetColor();
		}

		public void DrwTasks(int sel)
		{
			//Console.BackgroundColor = ConsoleColor.Black;
			//Console.ForegroundColor = ConsoleColor.Red;
			Tarefa t;
			string texto = "";

			for (int i = 0; i < ts.getTaskCount(); i++)
			{
				t = ts.getTask(i);
				if (sel == i)
				{
					Console.ForegroundColor = ConsoleColor.White;
					switch (t.Prioridade)
					{
						case 1:
							Console.BackgroundColor = ConsoleColor.DarkRed;
							break;
						case 2:
							Console.BackgroundColor = ConsoleColor.DarkYellow;
							break;
						case 3:
							Console.BackgroundColor = ConsoleColor.DarkGreen;
							break;
						case 4:
							Console.BackgroundColor = ConsoleColor.DarkBlue;
							break;
					}
					if(t.Status == 100)
					{
						Console.BackgroundColor = ConsoleColor.DarkGray;
					}
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.Black;
					switch (t.Prioridade)
					{
						case 1:
							Console.ForegroundColor = ConsoleColor.DarkRed;
							break;
						case 2:
							Console.ForegroundColor = ConsoleColor.DarkYellow;
							break;
						case 3:
							Console.ForegroundColor = ConsoleColor.DarkGreen;
							break;
						case 4:
							Console.ForegroundColor = ConsoleColor.DarkBlue;
							break;
					}
					if (t.Status == 100)
					{
						Console.ForegroundColor = ConsoleColor.Gray;
					}
				}
				Console.Write((char)9474);

				for (int j = 0; j < ts.getColCount(); j++)
				{
					switch(ts.getColName(j))
					{
						case "Prioridade":
							texto = t.Prioridade.ToString();
							break;

						case "Projeto":
							texto = t.Projeto;
							break;

						case "Titulo":
							texto = t.Titulo;
							break;

						case "Descricao":
							texto = t.Descricao;
							break;

						case "Usuario":
							texto = t.Usuario;
							break;

						case "Data":
							texto = t.Data;
							break;

						case "Status":
							texto = t.Status.ToString();
							break;
					}

					if (texto.Length > ts.getColSize(j))
					{
						string trim = texto;
						Console.Write(trim.Substring(0, ts.getColSize(j)));
					}
					else
					{
						int spaces = ts.getColSize(j) - texto.Length;
						Console.Write(texto);
						for (int k = 0; k < spaces; k++)
						{
							Console.Write(" ");
						}
					}
					Console.Write((char)9474);
				}
				Console.ResetColor();
				Console.WriteLine("");

			}
			Console.Write((char)9492);
			for (int i = 0; i < ts.getColCount(); i++)
			{
				for (int j = 0; j < ts.getColSize(i); j++)
				{
					Console.Write((char)9472);
				}
				Console.Write((char)9524);
			}
			Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
			Console.WriteLine((char)9496);

		}
		private void PrintTasks()
		{
			Console.SetCursorPosition(13, 0);
			Console.Write(tarefa.Prioridade);
			Console.WriteLine(" ");
			Console.SetCursorPosition(13, 1);
			Console.Write(tarefa.Projeto);
			Console.WriteLine(" ");
			Console.SetCursorPosition(13, 2);
			Console.Write(tarefa.Titulo);
			Console.WriteLine(" ");
			Console.SetCursorPosition(13, 3);
			Console.Write(tarefa.Usuario);
			Console.WriteLine(" ");
			Console.SetCursorPosition(13, 4);
			Console.Write(tarefa.Data+" ");
			date = DateTime.ParseExact(tarefa.Data, "dd/MM/yyyy", null);
			if((int)date.DayOfWeek == 6)
				Console.ForegroundColor = ConsoleColor.DarkYellow;
			else if((int)date.DayOfWeek == 0)
				Console.ForegroundColor = ConsoleColor.Red;
			else
				Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(date.ToString("ddd", new CultureInfo("pt-BR")).ToUpper());
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine(" ");
			Console.SetCursorPosition(13, 5);
			Console.Write(tarefa.Descricao);
			Console.WriteLine(" ");
		}

		public void DrwEdit(Tarefa t)
		{
			tarefaRef = t;
			tarefa.Prioridade = t.Prioridade;
			tarefa.Projeto = t.Projeto;
			tarefa.Titulo = t.Titulo;
			tarefa.Usuario = t.Usuario;
			tarefa.Descricao = t.Descricao;
			tarefa.Status = t.Status;
			tarefa.Data = t.Data;

			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;

			Console.WriteLine("Prioridade:" + "  ");
			Console.WriteLine("Projeto:" + "     ");
			Console.WriteLine("Titulo:" + "      ");
			Console.WriteLine("Usuário:" + "     ");
			Console.WriteLine("Data:" + "        ");
			Console.WriteLine("Descrição:" + "   ");
			Console.ResetColor();
			date = DateTime.ParseExact(tarefa.Data, "dd/MM/yyyy", null);
			PrintTasks();
			Console.SetCursorPosition(13, 0);
		}

		private int GetCampoSize(int campo)
		{
			int campoSize = 0;
			switch (campo)
			{
				case 0:
					campoSize = tarefa.Prioridade.ToString().Length;
					break;
				case 1:
					campoSize = tarefa.Projeto.ToString().Length;
					break;
				case 2:
					campoSize = tarefa.Titulo.ToString().Length;
					break;
				case 3:
					campoSize = tarefa.Usuario.ToString().Length;
					break;
				case 4:
					campoSize = tarefa.Data.ToString().Length;
					break;
				case 5:
					campoSize = tarefa.Descricao.ToString().Length;
					break;
			}
			return campoSize;
		}

		private void InsertChar(int campo, int pos, char c)
		{
			switch (campo)
			{
				case 1:
					tarefa.Projeto = tarefa.Projeto.ToString().Insert(pos, c.ToString());
					break;
				case 2:
					tarefa.Titulo = tarefa.Titulo.ToString().Insert(pos, c.ToString());
					break;
				case 3:
					tarefa.Usuario = tarefa.Usuario.ToString().Insert(pos, c.ToString());
					break;
				case 4:
					tarefa.Data = tarefa.Data.ToString().Insert(pos, c.ToString());
					break;
				case 5:
					tarefa.Descricao = tarefa.Descricao.ToString().Insert(pos, c.ToString());
					break;
			}
		}

		private void RemoveChar(int campo, int pos)
		{
			switch (campo)
			{
				case 1:
					tarefa.Projeto = tarefa.Projeto.ToString().Remove(pos, 1);
					break;
				case 2:
					tarefa.Titulo = tarefa.Titulo.ToString().Remove(pos, 1);
					break;
				case 3:
					tarefa.Usuario = tarefa.Usuario.ToString().Remove(pos, 1);
					break;
				case 4:
					tarefa.Data = tarefa.Data.ToString().Remove(pos, 1);
					break;
				case 5:
					tarefa.Descricao = tarefa.Descricao.ToString().Remove(pos, 1);
					break;
			}
		}

		public int GetKey(ConsoleKeyInfo k)
		{
			int left = Console.CursorLeft;
			int top = Console.CursorTop;
			switch (k.Key)
			{
				case ConsoleKey.PageUp:
				case ConsoleKey.UpArrow:
					if (top > 0)
						top--;
					left = GetCampoSize(top) + 13;
					Console.SetCursorPosition(left, top);
					break;

				case ConsoleKey.PageDown:
				case ConsoleKey.Tab:
				case ConsoleKey.DownArrow:
					if (top < 5)
						top++;
					left = GetCampoSize(top) + 13;
					Console.SetCursorPosition(left, top);
					break;

				case ConsoleKey.RightArrow:
					if (left < GetCampoSize(top) + 13)
						left++;
					Console.SetCursorPosition(left, top);
					break;

				case ConsoleKey.LeftArrow:
					if (left > 13)
						left--;
					Console.SetCursorPosition(left, top);
					break;

				case ConsoleKey.Backspace:
					if (left > 13)
					{
						left--;
					}
					RemoveChar(top, left - 13);
					PrintTasks();
					Console.SetCursorPosition(left, top);
					break;

				case ConsoleKey.Delete:
					RemoveChar(top, left - 13);
					PrintTasks();
					Console.SetCursorPosition(left, top);
					break;

				case ConsoleKey.Escape:
					return 0;
				
				case ConsoleKey.Add:
					if(top == 0)
					{
						if (tarefa.Prioridade < 4)
							tarefa.Prioridade++;
						PrintTasks();
						Console.SetCursorPosition(left, top);
					}
					else if(top == 4)
					{
						date = date.AddDays(1);
						tarefa.Data = date.ToString("dd/MM/yyyy");
						PrintTasks();
						Console.SetCursorPosition(left, top);
					}
					break;

				case ConsoleKey.Subtract:
					if (top == 0)
					{
						if (tarefa.Prioridade > 1)
							tarefa.Prioridade--;
						PrintTasks();
						Console.SetCursorPosition(left, top);
					}
					else if (top == 4)
					{
						date = date.AddDays(-1);
						tarefa.Data = date.ToString("dd/MM/yyyy");
						PrintTasks();
						Console.SetCursorPosition(left, top);
					}
					break;

				case ConsoleKey.Enter:
					tarefaRef.Prioridade = tarefa.Prioridade;
					tarefaRef.Projeto = tarefa.Projeto;
					tarefaRef.Titulo = tarefa.Titulo;
					tarefaRef.Usuario = tarefa.Usuario;
					tarefaRef.Descricao = tarefa.Descricao;
					tarefaRef.Status = tarefa.Status;
					tarefaRef.Data = tarefa.Data;
					return 0;

				default:
					if (k.KeyChar >= 32 && k.KeyChar < 255)
					{
						InsertChar(top, left - 13, k.KeyChar);
						PrintTasks();
						left++;
						Console.SetCursorPosition(left, top);
					}
					break;
					
			}
			return 1;   //retornou sem erros, e não precisa sair da tela
		}

		public void DrwAdd(Tarefa t)
		{
			tarefaRef = t;
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;

			Console.WriteLine("Prioridade:" + "  ");
			Console.WriteLine("Projeto:" + "     ");
			Console.WriteLine("Titulo:" + "      ");
			Console.WriteLine("Usuário:" + "     ");
			Console.WriteLine("Data:" + "        ");
			Console.WriteLine("Descrição:" + "   ");
			Console.ResetColor();

			tarefa.Prioridade = 3;
			tarefa.Titulo = "";
			tarefa.Projeto = "";
			tarefa.Descricao = "";
			tarefa.Usuario = "";
			tarefa.Status = 0;
			tarefa.Data = date.ToString("dd/MM/yyyy");

			PrintTasks();
			Console.SetCursorPosition(13, 0);
		}
	}
}
