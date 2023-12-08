select *from "Foto"
select *from "Medidas"
select *from "Usuario"
select *from "Precio"

//consulta 1
SELECT "Titulo" FROM "Foto" WHERE "Titulo" LIKE 'e%'
//consulta 2
select p."Titulo" from "Foto" as p join "Usuario" as u on p."IdUsuario" = u."idUsuario" where u."idUsuario" =5 
//consulta 3
select * from "Foto" as p join "Usuario" as u on p."IdUsuario" = u."idUsuario" where u."idUsuario" =5 
//consulta 4
select *from "Usuario" where "Edad">25
//consulta 5
select m."Cantidad",m."Tamanio" from "Usuario"  as u
join "Foto" as f on u."idUsuario" = f."IdUsuario" 
join "Medidas" as m on f."IdMedidas" = m."IdMedida"
where m."Calidad" ='Alta'
//consultas 6
select * from "Usuario"  as u
join "Foto" as f on u."idUsuario" = f."IdUsuario" 
join "Medidas" as m on f."IdMedidas" = m."IdMedida"
where m."Cantidad" <10 and m."Tamanio"='grande'
//consultas 7
select m."Tamanio" from "Usuario"  as u
join "Foto" as f on u."idUsuario" = f."IdUsuario" 
join "Medidas" as m on f."IdMedidas" = m."IdMedida"
where m."Calidad"='Baja' or m."Cantidad" >15
//consultas 8
select p."Costo" from "Usuario"  as u
join "Foto" as f on u."idUsuario" = f."IdUsuario" 
join "Precio" as p on f."IdPrecio" = p."IdPrecio"
where u."idUsuario"=1








































