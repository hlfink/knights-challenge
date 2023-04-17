import { Component, OnInit } from '@angular/core';
import {KnightService} from 'src/app/services/knight.service';
import  {knightResponse} from 'src/app/knightResponse';
import { ActivatedRoute } from '@angular/router';
declare var window: any;
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})

export class SearchComponent implements OnInit {
  
  knightList: knightResponse[] = []
  knightListFilter : knightResponse[] = []
  heroes = false
  id!: string
  formModal: any

  constructor(private knightService : KnightService ,private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {

    this.activatedRoute.queryParams.subscribe(params=> {
      this.heroes = params['heroes'] == null ? false : true
      this.getAll()
      this.formModal = new window.bootstrap.Modal(
        document.getElementById('confirmModal')
      );
    })
  }
  async getAll() {
    this.knightService.getAll().subscribe((response) => {
      
      this.knightList = response
      this.findHeroes()
    });
  }

  find(e : Event) : void {

    const target = e.target as HTMLInputElement
    const value = target.value.toLowerCase()

    if(value == ""){
      this.knightListFilter =  this.knightList
      return
    }
    this.knightListFilter = this.knightList.filter(k => k.id.toLowerCase().includes(value))
  }

  findHeroes(){
    this.knightListFilter = this.knightList;
    
    if (this.heroes)
      this.knightListFilter = this.knightList.filter(k => k.experiense > 0)
  }

  openModal(id : string){
    this.id = id;
    this.formModal.show()
  }
 
  remove(){
    var index = 0;
    var id = this.id

    this.knightListFilter.some(function (elem, i) {
        return elem.id === id ? (index = i, true) : false;
    });

    this.knightListFilter.splice(index ,1)
    this.knightService.delete(this.id).subscribe(success => { console.log(success)});
    this.closeModal()
    this.id="";
    
  }
  closeModal(){
    this.formModal.hide();
  }
 }
