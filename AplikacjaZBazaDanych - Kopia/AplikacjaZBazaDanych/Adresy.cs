namespace AplikacjaZBazaDanych
{
    partial class Osoba
    {
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }
    }
}
