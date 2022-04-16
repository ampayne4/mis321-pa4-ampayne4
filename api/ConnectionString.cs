namespace api
{
    public class ConnectionString
    {
        public string cs {get;set;}
        
        public ConnectionString()
        {
            string server = "jhdjjtqo9w5bzq2t.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "vjvw7gzux5bhfrtd";
            string port = "3306";
            string username = "ezdxlzhetorndo5t";
            string password = "xfdwtsnluh7mwpjk";

            cs = $@"server = {server}; user = {username}; database = {database}; port = {port}; password = {password};";    

        }
    }
}