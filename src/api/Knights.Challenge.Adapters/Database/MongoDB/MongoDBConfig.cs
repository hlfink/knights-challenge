namespace Knights.Challenge.Adapters.Database.MongoDB
{
    public class MongoDBConfig
    {
        public string? Database { get; set; }
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public bool SRV { get; set; }

        public string ConnectionString
        {
            get 
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://{Host}:{Port}";

                if (SRV)
                    return $@"mongodb+srv://{User}:{Password}@{Host}";

                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
}

    }
}
