import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../../models/user';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = new User();

  constructor(
    private _router: Router,
    private _userService: UserService,
    private _activedRoute: ActivatedRoute,
    private _toastr: ToastrService
  ) { }
  ngOnInit() {
  }

  userLogin() {
    this._userService.userLogin(this.user).subscribe(
      res => {
        console.log('response', res)
        if (res.email != "") {
          this._router.navigateByUrl('/mainPage');
        }
      }
    );
  }
}
