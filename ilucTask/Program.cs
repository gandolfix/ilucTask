using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilucTask
{
	class Program
	{
		enum Telas
		{
			Tabela,
			Edit,
			Add
		}
		static void Main(string[] args)
		{
			int sel;
			int getAnswer = 0;
			Telas tela;
			ConsoleKey k = ConsoleKey.F24;
			Tarefas ts = new Tarefas();
			Prompt p = new Prompt(ts);
			Tarefa t = new Tarefa();
			Console.CursorSize = 4;
			Console.Title = "ilucTask 1.0";
			ts.orderBy(0, 4);	//0 ordena pela prioridade, e 4 ordena pela Data
			sel = 0;
			tela = Telas.Tabela;
			do
			{
				switch (tela)
				{
					case Telas.Tabela:
						Console.CursorVisible = false;
						Console.SetCursorPosition(0, 0);
						//Console.Clear();
						p.DrwHeader();
						p.DrwTasks(sel);

						k = Console.ReadKey().Key;
						switch (k)
						{
							case ConsoleKey.UpArrow:
								if (sel > 0)
									sel--;
								break;

							case ConsoleKey.DownArrow:
								if (sel < ts.getTaskCount() - 1)
									sel++;
								break;

							case ConsoleKey.RightArrow:
								t = ts.getTask(sel);
								if (t.Status < 100)
									t.Status = t.Status + 10;
								ts.updateTask(t, sel);
								if(t.Status == 100)
								{
									Console.SetCursorPosition(0, 0);
									ts.orderBy(0, 4);   //0 ordena pela prioridade, e 4 ordena pela Data
									p.DrwHeader();
									p.DrwTasks(sel);
								}
								break;

							case ConsoleKey.LeftArrow:
								t = ts.getTask(sel);
								if (t.Status >= 10)
									t.Status = t.Status - 10;
								ts.updateTask(t, sel);
								break;

							case ConsoleKey.E:
							case ConsoleKey.Enter:
								t = ts.getTask(sel);
								tela = Telas.Edit;
								//campo = 0;
								Console.Clear();
								Console.CursorVisible = true;
								p.DrwEdit(t);
								break;

							case ConsoleKey.A:
								//t = null;
								t = new Tarefa();
								tela = Telas.Add;
								//campo = 0;
								Console.Clear();
								Console.CursorVisible = true;
								p.DrwAdd(t);
								break;

							case ConsoleKey.Delete:
								Console.Clear();
								ts.deleteTask(sel);
								break;
						}
						break;

					case Telas.Edit:
						getAnswer = p.GetKey(Console.ReadKey(true));
						if (getAnswer == 0)
						{
							tela = Telas.Tabela;
							ts.orderBy(0, 4);   //0 ordena pela prioridade, e 4 ordena pela Data
						}
						else if (getAnswer == 0)
						{

						}
						break;

					case Telas.Add:
						getAnswer = p.GetKey(Console.ReadKey(true));
						if (getAnswer == 0)
						{
							tela = Telas.Tabela;
							ts.addTask(t);
							ts.orderBy(0, 4);   //0 ordena pela prioridade, e 4 ordena pela Data
						}
						else if (getAnswer == 0)
						{

						}
						//Console.Clear();
						//p.DrwAdd();
						/*switch (campo)
						{
							case 0:
								Console.CursorVisible = true;
								Console.SetCursorPosition(13, campo);
								string str = Console.ReadLine();
								int priori = Convert.ToInt32(str);
								if (priori == 0 || priori > 4)
									priori = 3;
								t.Prioridade = priori;
								campo++;
								break;

							case 1:
								Console.SetCursorPosition(13, campo);
								t.Projeto = Console.ReadLine();
								campo++;
								break;

							case 2:
								Console.SetCursorPosition(13, campo);
								t.Titulo = Console.ReadLine();
								campo++;
								break;

							case 3:
								Console.SetCursorPosition(13, campo);
								t.Usuario = Console.ReadLine();
								campo++;
								break;

							case 4:
								Console.SetCursorPosition(13, campo);
								t.Data = Console.ReadLine();
								campo++;
								break;

							case 5:
								Console.SetCursorPosition(13, campo);
								t.Descricao = Console.ReadLine();
								campo++;
								break;

							case 6:
								t.Status = 0;
								tela = Telas.Tabela;
								ts.addTask(t);
								break;

						}*/
						break;
				}

			} while (k != ConsoleKey.Q && k != ConsoleKey.Escape);
			ts.save();
		}
	}
}