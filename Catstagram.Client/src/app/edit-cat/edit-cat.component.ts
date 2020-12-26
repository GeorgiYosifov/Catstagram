import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CatService } from '../services/cat.service';
import { Cat } from '../models/Cat';

@Component({
  selector: 'app-edit-cat',
  templateUrl: './edit-cat.component.html',
  styleUrls: ['./edit-cat.component.css']
})
export class EditCatComponent implements OnInit {
  catForm: FormGroup;
  catId: string;
  cat: Cat;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private catService: CatService,
    private router: Router) {

    this.catForm = this.fb.group({
      "id": [''],
      "description": ['']
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(res => {
      this.catId = res['id'];
      this.catService.getCat(this.catId).subscribe(res => {
        this.cat = res;
        this.catForm = this.fb.group({
          "id": [this.cat.id],
          "description": [this.cat.description]
        });
      });
    });
  }
  
  editCat() {
    this.catService.editCat(this.catForm.value).subscribe(res => {
      this.router.navigate(["cats"]);
    });
  }
}
