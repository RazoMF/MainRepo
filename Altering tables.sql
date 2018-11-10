create table big_table
as
select rownum id, a.*
 from all_objects a
 where 1=0 