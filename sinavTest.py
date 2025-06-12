Sonuclar = []

while 1:
    sayi1 = int(input('Birinci Sayı:'))
    sayi2 = int(input('ikinci Sayı:'))
    operator = input('işlem("+","-","*","/", (çıkış için "q")): ')
    islemSonuc = 0
    islemAdi = ""
    if operator == "q":
        print("Çıkış Yapıldı")
        break
    if operator == '+':
        islemSonuc = sayi1+sayi2
        print('Sonuç: '+ str(islemSonuc))
    elif operator == '-':
        islemSonuc = sayi1-sayi2
        print('Sonuç: '+ str(islemSonuc))
    elif operator == '*':
        islemSonuc = sayi1*sayi2
        print('Sonuç: '+ str(islemSonuc))
    elif operator == '/':
        islemSonuc = sayi1/sayi2
        print('Sonuç: '+ str(islemSonuc))
    
    #Open & Write+
    file = open("islemKayitlari.txt","w+")
    Sonuclar.append("İşlem ="+str(sayi1)+operator+str(sayi2)+" Sonuç= "+str(islemSonuc)+" \n")
    file.writelines(Sonuclar)
    file.close()

#Open & Read+
file = open("islemKayitlari.txt","r+")
results = [i for i in file.readlines()]
rsltStr = ""
for i in results:
    rsltStr += i
print(rsltStr)