/*
TUTORIAL:
    1 parâmetro -> Lista que se deseja ordenar;
    2 parâmetro -> Nome da propriedade de comparação. (Ex.: quantidade, nome, cor...);
    3 parâmetro -> tipo de ordenação (o padrão é Ascendente, caso queira por ordem descendente é só passar true);
*/

function ordenar(list = [], propName = "", descending = false) {
    let orderedList = [];

    orderedList = list.sort(function(a, b) {
        if (a[propName] > b[propName]) {
            return descending ? -1 : 1;
        }

        if (a[propName] < b[propName]) {
            return descending ? 1 : -1;
        }

        return 0;
    });

    return orderedList;
}