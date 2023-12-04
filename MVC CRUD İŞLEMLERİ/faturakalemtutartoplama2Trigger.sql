CREATE TRIGGER TUTAREKLE
ON FaturaKalems
AFTER INSERT
AS
DECLARE @Faturaid int
DECLARE @Tutar decimal(18,2)
Select @Faturaid=faturaid,@tutar=tutar from inserted
update Faturalars set Toplam=Toplam + @Tutar where Faturaid=@Faturaid