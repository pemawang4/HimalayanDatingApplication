import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
//import { debug } from 'console';
import { Observable } from 'rxjs';
import { Preference } from '../models/preference';
import { User } from '../models/user';
import { PreferenceService } from '../Services/preference.service';
import { UserService } from '../Services/user.service';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-preference',
  templateUrl: './preference.component.html',
  styleUrls: ['./preference.component.css']
})
export class PreferenceComponent implements OnInit {
  user: User = new User();
  preference: Preference = new Preference();

  id: string;
  constructor(
    private route: ActivatedRoute,
    private _userService: UserService,
    private _router: Router,
    private _toastr: ToastrService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => (this.id = params.get('id')));
    this.getUser(this.id);
    if (this.id != "") {
      this._toastr.success("User created successfully.", "Registration Status");
    }
  }

  getUser(id: string) {
    this._userService.getUser(id).subscribe(
      res => {
        this.id = res;
      });
  }

  savePreference() {
    this.preference.userId = this.id;
    this._userService.savePreference(this.preference).subscribe(
      res => {
        //console.log('respoonse', res);
        this._router.navigateByUrl('/mainPage/' + res);
      }
    );
  }
}
