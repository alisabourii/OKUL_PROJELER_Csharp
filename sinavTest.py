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
    
    file = open("islemKayitlari.txt","w+")
    Sonuclar.append("İşlem ="+str(sayi1)+operator+str(sayi2)+" Sonuç= "+str(islemSonuc)+" \n")
    print(Sonuclar)
    file.writelines(Sonuclar)
    file.close()