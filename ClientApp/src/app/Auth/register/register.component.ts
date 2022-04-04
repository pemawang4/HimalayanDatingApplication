import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../../models/user';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: User = new User();

  constructor(
    private _userService: UserService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _toastr: ToastrService,
  ) { }

  ngOnInit() {
  }

  saveUser() {
    this._userService.saveUser(this.user).subscribe(
      res => {
        if (res.email != '') {
          this._router.navigateByUrl('/preference/' + res);
        }
        //this._toastr.success("User created successfully.", "Registration Status");
      },
      err => {
        console.log(err)
      }
    );
  }
}
