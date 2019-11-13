using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ilucTask
{
	class Tarefas
	{
		//Tarefa t = new Tarefa();
		List<Tarefa> tarefas = new List<Tarefa>();
		List<Coluna> colunas = new List<Coluna>();
		public Tarefas()
		{
			string json = System.IO.File.ReadAllText(@"tarefas.json");
			tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(json);
			string colTxt = System.IO.File.ReadAllText(@"colunas.json");
			colunas = JsonConvert.DeserializeObject<List<Coluna>>(colTxt);
		}

		public void orderBy(int param1, int param2)
		{
			switch(param1)
			{
				case 0:
					tarefas = tarefas.OrderBy(x => x.Prioridade).ToList();
					break;
				case 1:
					tarefas = tarefas.OrderBy(x => x.Projeto).ToList();
					break;
				case 2:
					tarefas = tarefas.OrderBy(x => x.Titulo).ToList();
					break;
				case 3:
					tarefas = tarefas.OrderBy(x => x.Usuario).ToList();
					break;
				case 4:
					tarefas = tarefas.OrderBy(x => x.Data).ToList();
					break;
				case 5:
				default:
					tarefas = tarefas.OrderBy(x => x.Status).ToList();
					break;
			}
			switch (param2)
			{
				case 0:
					tarefas = tarefas.OrderBy(x => x.Prioridade).ToList();
					break;
				case 1:
					tarefas = tarefas.OrderBy(x => x.Projeto).ToList();
					break;
				case 2:
					tarefas = tarefas.OrderBy(x => x.Titulo).ToList();
					break;
				case 3:
					tarefas = tarefas.OrderBy(x => x.Usuario).ToList();
					break;
				case 4:
					tarefas = tarefas.OrderBy(x => x.Data).ToList();
					break;
				case 5:
				default:
					tarefas = tarefas.OrderBy(x => x.Status).ToList();
					break;
			}
			tarefas = tarefas.OrderByDescending(x => x.Status == 100).ToList();
		}

		public string getColName(int id)
		{
			return colunas[id].Nome;
		}

		public string getColText(int id)
		{
			return colunas[id].Texto;
		}

		public int getColSize(int id)
		{
			return colunas[id].Tamanho;
		}

		public int getColCount ()
		{
			return colunas.Count;
		}

		public int getTaskCount ()
		{
			return tarefas.Count;
		}

		public Tarefa getTask(int id)
		{
			return tarefas[id];
		}

		public void addTask (Tarefa t)
		{
			tarefas.Add(t);
		}

		public void updateTask(Tarefa t,int id)
		{
			tarefas[id].Status = t.Status;
			if (t.Status == 100)
			{
				tarefas[id].Data = DateTime.Now.ToString("dd/MM/yyyy");
			}

		}

		public void deleteTask(int id)
		{
			tarefas.RemoveAt(id);
		}

		public void save()
		{
			System.IO.File.WriteAllText(@"tarefas.json", JsonConvert.SerializeObject(tarefas, Formatting.Indented));
		}
	}
}
