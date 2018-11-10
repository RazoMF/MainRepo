select 1+null, 1-null,1*null,1/null
from dual;

with 
smpl 
  as
(
  select 1 as a from dual
  union all
  select 2 from dual
  union all
  select NULL from dual
)
select min(a), max(a), avg(a), sum(a)
from smpl;

with 
smpl as 
(
  select 1 as a from dual
  union all  
  select 2 from dual
  union all
  select NULL from dual
)
select a
from smpl
--where null is null -true, null = null -false, null != null -false, null > 0 -false, null < 0 -false, null != 0 -false
order by a nulls last;




