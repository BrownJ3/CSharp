void Main()
{
	string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\testfolder\ex150602.log");
			
			var count = lines.Count()/16;
			string.Format("Total Site Hits: {0}", count).Dump();
	        string search =  "MSIE\\+8.0";  
			
			List<string> allIps = new List<string>();
			List<string> ie8Ips = new List<string>();
		
	        foreach (string line in lines)
	        {
			
				if(line.Length>=1 && line.Substring(0,1)=="#")
				{
					continue;
				}
	           string[] log = line.Split(' ');
			   		   
				
				if(!allIps.Contains(log[8]))
					allIps.Add(log[8]);
				
	            if (System.Text.RegularExpressions.Regex.IsMatch(line, search)) 
	            {
					
					if(!ie8Ips.Contains(log[8]))
						ie8Ips.Add(log[8]);
					
				}
			
			}
			
			
			var visitors = allIps.Count();
			var ie = ie8Ips.Count();
			
			string.Format("Unique Site visitors: {0}", visitors).Dump();
			string.Format("All visitors with IE8: {0}", ie).Dump();
			ie8Ips.Dump();
}