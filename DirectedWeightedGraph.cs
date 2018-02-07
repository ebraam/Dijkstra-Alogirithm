using System;
namespace dijkstraShortestPathProject
{
	class DirectedWeightedGraph
	{
		public readonly int Max_Vertices = 30;
		int n;
		int e;
		int[,] adj;
		Vertex[] vertexList;
		
		//specify status
		private readonly int Temporary = 1;
		private readonly int Permanent = 2;
		// used to initialize  predecessor
		private readonly int NIL = -1;
		// used to initialize path length
		private readonly int INFINIT = 9999999;
		
		public DirectedWeightedGraph()
		{
			adj = new int [Max_Vertices, Max_Vertices];
			vertexList = new Vertex[Max_Vertices];
			}
			
			// function to set predecessor and path length for all 
			//vertices we will call it in public method call FindPath
			private void  Dijkstra(int s)
			{
				int v , c;
				for(v =0; v < n; v++){
				vertexList[v].status = Temporary;
				vertexList[v].pathLength = INFINIT;
				vertexList[v].predecessor = NIL;
				}
				vertexList[s].pathLength = 0;
				while(true)
				{
					c = TempVertexMinPL();
					if (c == NIL)
					return;
					
					vertexList[c].status = Permanent;
					
					for(v = 0; v < n; v++)
					{
						if (IsAdjacent(c,v) && vertexList[v].status == Temporary)
							if(vertexList[c].pathLength + adj[c,v] < vertexList[v].pathLength[v])
							{
								vertexList[v].predecessor = c;
								vertexList[v].pathLength = vertexList[c].pathLength+ adj[c,v];
							}
						}
					}
				}
				
				private int TempVertexMinPL()
					{
						int min = INFINIT;
						int x = NIL;
						for ( int v = 0 ; v < n ; v++ )
						{
							if (vertexList[v].status == Temporary && vertexList[v].pathLength < min)
							{
								min = vertexList[v].pathLength;
								x = v;
							}
						}
						return x;
					}
				public void FindPath(String source)
					{
						int s = GetIndex( source );
						 Dijkstra(s);
						 
						 Console.WriteLine("Source Vertex : "+ source "+"\n");
						 
						 for( int v =0; v < n; v++)
							{
								Console.WriteLine("Destination vertex : "+vertexList[v].name);
								if(vertexList[v].pathLength == INFINIT)
								Console.WriteLine("There is no path from " +source+ "to vertex" + vertexList[v].name);
								else
									FindPath(s ,v);
							}
					}
					
				private void FindPath( int s, int v)
					{
						int i, u;
						int [] path= new int [n]; //store path from source to vertex s to destination
						int sd = 0; //variable store shortest destance from S to V
						int count = 0; //variable count number of vertices in that shortest path
						while ( v != s)
						 {
							count ++ ;
							path[count] = v;
							u = vertexList[v].predecessor;
							sd += adj[ u, v];
							v = u;
						}
						
						count++;
						path[count] = s;
						
						Console.Write("shortest path is : ");
						
			}
			
			