function createSortedList(){
    let sortList = function(list){
        return list.sort((a,b) => a - b);
    }
    
    let sortedList = {
        elemnts: [],
        size: 0,
        add(element){
            this.elemnts.push(element);
            this.size++;
            sortList(this.elemnts);
        },
        remove(index){
            if(index < 0 || index >= this.elemnts.length){
                return;
            }

            let elementToDelete = this.elemnts.splice(index,1);
            this.size--;
        },
        get(index){
            if(index < 0 || index >= this.elemnts.length){
                return;
            }
            return this.elemnts[index];
        },
    }
    return sortedList;
}

let list =createSortedList();
list.add(5);
console.log(list.size());
list.add(6);
for(let i = 0; i < 22; i++){
    list.add(7);

}
console.log(list.size()); 
list.remove(1);
console.log(list.get(1));
