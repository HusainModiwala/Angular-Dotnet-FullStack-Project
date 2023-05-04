import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, searchTerm: string) {
    if(value.length === 0 || searchTerm === ''){
      return value;
    }
    const users:any = [];
    for(const user of value){
      console.log(user.email);
      if(user.email === searchTerm){
        users.push(user);
      }
    }
    console.log(users);
    return users;
  }

}
