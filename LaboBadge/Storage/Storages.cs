namespace LaboBadge.Storage
{
    public  class Storages
    {
        private readonly string _NameStorage;
        public Storages(string nameStorage)
        {
            this._NameStorage = nameStorage;
        }

        public List<string> storagesKey { get; set; }

        public List<string> StorageValue { get; set; }

        public string GetValueStorage(string key)
        {
            string res ="";
            if (storagesKey == null) return null;
            for (int i = 0; i < storagesKey.Count; i++)
            {
                if (key == storagesKey[i])
                {
                    res = StorageValue[i];
                }
                else
                {
                    return null;
                }
            }
            return res;
        }
        public void SetValueStorage(string key , string value)
        {
            storagesKey.Add(key);
            StorageValue.Add(value);
        }

    }
}
