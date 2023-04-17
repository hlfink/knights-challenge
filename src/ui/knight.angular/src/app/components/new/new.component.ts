import { Component, OnInit } from '@angular/core';
import {
   AbstractControl, FormBuilder, FormGroup, Validators, FormControl
} from '@angular/forms';
import { knightRequest } from 'src/app/knightRequest';
import { KnightService} from 'src/app/services/knight.service'


@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {

  newForm: FormGroup =  new FormGroup({
    name: new FormControl('', [Validators.required]),
    nickname: new FormControl('', [Validators.required]),
    birthday: new FormControl('', [Validators.required]),
    keyAttribute: new FormControl('', [Validators.required]),
    strength: new FormControl('', [Validators.required]),
    dexterity: new FormControl('', [Validators.required]),
    constitution: new FormControl('', [Validators.required]),
    intelligence: new FormControl('', [Validators.required]),
    charisma: new FormControl('', [Validators.required]),
    wisdom: new FormControl('', [Validators.required]),
  });

  weaponForm: FormGroup = new FormGroup({
    wname: new FormControl('', [Validators.required]),
    mod: new FormControl('', [Validators.required]),
    wattr : new FormControl('', [Validators.required]),
    equipped: new FormControl('', [Validators.required]),
  });

  knight!: knightRequest
  success = false

  constructor(private knightService: KnightService) {}

  ngOnInit() : void {
    this.knight = {birthday : new Date(), name : '', nickName : '', attributes :{}, weapons : [], keyAttribute : ''}
  }

  get f(): { [key: string]: AbstractControl } {
    console.log(this.newForm.controls)
    return this.newForm.controls;
  }

  get w(): { [key: string]: AbstractControl } {
    console.log(this.weaponForm.controls)
    return this.weaponForm.controls;
  }

  submit(){
    if(this.newForm.invalid)
      return;

    if(this.knight.weapons.length ==0)
      return;

      this.knight.birthday = this.newForm.get('birthday')?.value;
      this.knight.name = this.newForm.get('name')?.value;
      this.knight.nickName = this.newForm.get('nickname')?.value;
      this.knight.keyAttribute = this.newForm.get('keyAttribute')?.value.toLowerCase()

      this.knight.attributes = {
        'strength' : parseInt(this.newForm.get('strength')?.value)
        ,'dexterity' : parseInt(this.newForm.get('dexterity')?.value)
        ,'constitution' : parseInt(this.newForm.get('constitution')?.value)
        ,'intelligence' : parseInt(this.newForm.get('intelligence')?.value)
        ,'charisma' : parseInt(this.newForm.get('charisma')?.value )
        ,'wisdom' : parseInt(this.newForm.get('wisdom')?.value )
      };

      this.knightService.create(this.knight).subscribe((response : any) =>{ 
       this.success = true;
       this.reset()
      }
      ,error => { console.log(error)})
  }

  addWeapon(){
    if(this.weaponForm.invalid)
      return;
      
      this.knight.weapons.push({
        name : this.weaponForm.get('wname')?.value 
      , attr :this.weaponForm.get('wattr')?.value.toLowerCase()
      , equipped : this.weaponForm.get('equipped')?.value == '0' ? true: false  
      , mod : this.weaponForm.get('mod')?.value })
  }
  deleteWeapon(index: number){

    if(index != -1)
      this.knight.weapons.splice(index,1)
  }
  
  reset(){
    this.newForm.reset()
    this.weaponForm.reset()
    scroll(0, 10)
  }
}
 