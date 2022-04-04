import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MatchList } from '../models/match-list';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private _userService: UserService,
    private _router: Router,
    private _toastr: ToastrService,
    private _matchList: MatchList
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => (this.id = params.get('id')));
    this.getMatchList(this.id);
  }

  getMatchList(id: string) {

  }
}
