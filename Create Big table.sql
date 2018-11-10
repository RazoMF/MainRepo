create table big_table
as
select rownum id, a.*
 from all_objects a
 where 1=0;
 
 select * from big_table
 
 alter table big_table nologging; 
 
 declare
 cnt_p number;
 rows_p number := 1000000;
begin
 insert /*+ append */ 
 into big_table
 select rownum, a.*
 from all_objects a
 where rownum <= 1000000;
 cnt_p := sql%rowcount;
 commit; 
 
 while (cnt_p < rows_p)
 loop
   insert /*+ APPEND */ into big_table
   select rownum+cnt_p,
   OWNER, OBJECT_NAME, SUBOBJECT_NAME, OBJECT_ID, DATA_OBJECT_ID,
   OBJECT_TYPE, CREATED, LAST_DDL_TIME, TIMESTAMP, STATUS,
   TEMPORARY, GENERATED, SECONDARY, NAMESPACE, EDITION_NAME
   from big_table
   where rownum <= rows_p-cnt_p;
   cnt_p := cnt_p + sql%rowcount;
   commit;
 end loop;
end; 
 
 