import { Component, OnInit } from '@angular/core';
import { CatService } from '../services/cat.service';
import { Router } from '@angular/router';
import { Cat } from '../models/Cat';

@Component({
  selector: 'app-list-cats',
  templateUrl: './list-cats.component.html',
  styleUrls: ['./list-cats.component.css']
})
export class ListCatsComponent implements OnInit {
  cats: Array<Cat>

  constructor(private catService:CatService, private router: Router) { }

  ngOnInit(): void {
    this.getCats();
  }

  getCats () {
    this.catService.getCats().subscribe(cats => {
      this.cats = cats;
    });
  }

  editCat(id) {
    this.router.navigate(["cats/" + id + "/edit"]);
  }

  deleteCat(id) {
    this.catService.deleteCat(id).subscribe(res => {
      this.getCats();
    });
  }
}
