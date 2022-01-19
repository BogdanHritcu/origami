import { Component, OnInit } from '@angular/core';
import { Profile } from 'src/app/interfaces/profile';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public myProfile: Profile = {
    username: '',
    picturePath: '',
    firstName: '',
    lastName: '',
    birthday: new Date(),
    description: '',
    comments: []
  };

  constructor(private privateService: PrivateService) { }

  ngOnInit(): void {
    this.getMyProfile();
  }

  getMyProfile() {
    this.privateService.getMyProfile().subscribe((response: any) => {
      this.myProfile = response;
    });
  }
}
