import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { CatService } from '../services/cat.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {
  catForm: FormGroup;

  constructor(private fb: FormBuilder, private catService: CatService, private toastrService: ToastrService) {
    this.catForm = this.fb.group({
      'imageUrl': ['', Validators.required],
      'description': ['']
    });
   }

  ngOnInit(): void {
  }

  get imageUrl() {
    return this.catForm.get('imageUrl');
  }
  
  create() {
    this.catService.create(this.catForm.value).subscribe(res => {
      this.toastrService.success("Success");
      console.log(res);
    })
  }
}
