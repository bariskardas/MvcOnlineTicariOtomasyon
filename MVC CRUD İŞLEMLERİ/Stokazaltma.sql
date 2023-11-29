Create Trigger SatisStokAzalt
On SatisHarekets
After insert
as
Declare @Urunid int
Declare @Adet int
Select @Urunid=Urunid, @Adet=Adet from inserted
Update Uruns set stok=stok-@Adet where Urunid=@Urunid