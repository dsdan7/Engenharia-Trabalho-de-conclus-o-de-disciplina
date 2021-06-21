char ser = '0';
char ligado='0';
int botao [9]={0,0,0,0,0,0,0,0,0};
void setup() {
  Serial.begin(9600);

  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);

}


void triggerPin(int pin) {
  digitalWrite(pin, HIGH);
  delay(250);
  digitalWrite(pin, LOW);
}


void loop() {
  if (Serial.available()) {


    ser = Serial.read();
   

    if (ser == 'l') {
          for(int cont=2;cont<10;cont++){
            digitalWrite(cont, HIGH);
            botao[cont-1]=1;
          }
          
    }
    if(ser == 'd')
    {
       for(int cont=2;cont<10;cont++){
            digitalWrite(cont, LOW);
            botao[cont-1]=0;
          }
          
    }
    else if(botao[ser-'0']==1){
      digitalWrite((ser-'0')+1,LOW);
      botao[ser-'0']=0;
      }
    else if(botao[ser-'0']==0){
      digitalWrite((ser-'0')+1,HIGH);
      botao[ser-'0']=1;
        }
    
   
  }
}
