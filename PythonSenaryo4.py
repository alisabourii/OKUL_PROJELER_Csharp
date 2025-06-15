fileOku = open("siparisler.txt", "r")
FilSatir = fileOku.readlines()
fileOku.close()
toplam = 0
for line in FilSatir:
        ayirici = line.split(",")
        toplam += int(ayirici[2])
        if(int(ayirici[2]) >= 5000):
                print(ayirici[0]+"-"+ayirici[1]+"("+ayirici[2]+")Pahalı Sipariş")
        else:
                print(ayirici[0]+"-"+ayirici[1]+"("+ayirici[2]+")Uygun Sipariş")
print(F"Toplam Sipariş Tutuarı:{toplam}")
